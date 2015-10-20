namespace CloudTemple.Logic
{
    using System;
    using System.Collections.Generic;

    using Excel;
    using Excel.Contracts;

    using Models;

    using MongoDB;
    using MongoDB.Contracts;

    using SQLServer;
    using SQLServer.Contracts;

    public class ExcelReportsLoader
    {
        private readonly IExcelXlsData excelXlsData;

        private readonly IMongoDbData mongoData;

        private readonly ISqlServerData msSqlData;

        public ExcelReportsLoader()
            : this(new SqlServerData(), new MongoDbData(), new ExcelXlsData())
        {
        }

        public ExcelReportsLoader(
            ISqlServerData msSqlDataToUse,
            IMongoDbData mongoDbDataToUse,
            IExcelXlsData excelXlsDataToUse)
        {
            this.msSqlData = msSqlDataToUse;
            this.mongoData = mongoDbDataToUse;
            this.excelXlsData = excelXlsDataToUse;
        }

        public void Load()
        {
            Console.WriteLine("Adding data to SQL Server...");

            if (this.msSqlData.Products.GetById(1) != null)
            {
                Console.WriteLine("Data already exists - aborting...");
                return;
            }

            this.LoadDataFromMongo();

            this.LoadDataFromZippedExcelFile();

            this.msSqlData.SaveChanges();
        }

        private void LoadDataFromMongo()
        {
            Console.WriteLine("Adding product categories from MongoDB to SQL Server...");
            foreach (var category in this.mongoData.GetAllProductCategories())
            {
                this.msSqlData.ProductCategories.Add(category);
            }

            Console.WriteLine("Adding product details from MongoDB to SQL Server...");
            foreach (var detail in this.mongoData.GetAllProductDetails())
            {
                this.msSqlData.ProductDetails.Add(detail);
            }

            Console.WriteLine("Adding vendors from MongoDB to SQL Server...");
            foreach (var vendor in this.mongoData.GetAllVendors())
            {
                this.msSqlData.Vendors.Add(vendor);
            }

            Console.WriteLine("Adding products from MongoDB to SQL Server...");
            foreach (var product in this.mongoData.GetAllProducts())
            {
                this.msSqlData.Products.Add(product);
            }
        }

        private void LoadDataFromZippedExcelFile()
        {
            var setOfLocations = new HashSet<string>();

            this.excelXlsData.ReadAllPurchases(
                (productId, quantity, unitPrice, locationName, date) =>
                    {
                        if (setOfLocations.Contains(locationName))
                        {
                            return;
                        }

                        setOfLocations.Add(locationName);
                    });

            var dictionaryWithLocations = new Dictionary<string, int>();
            var index = 1;

            Console.WriteLine("Adding purchase locations from ZIP file with Excel reports to SQL Server...");
            foreach (var location in setOfLocations)
            {
                this.msSqlData.PurchaseLocations.Add(new PurchaseLocation { Name = location });

                dictionaryWithLocations.Add(location, index);
                index++;
            }

            Console.WriteLine("Adding purchases from ZIP file with Excel reports to SQL Server (hang tight)...");
            this.excelXlsData.ReadAllPurchases(
                dictionaryWithLocations,
                purchase => { this.msSqlData.Purchases.Add(purchase); });
        }
    }
}