namespace CloudTemple.Logic
{
    using System;
    using System.Linq;

    using MongoDB;
    using MongoDB.Contracts;

    using SQLServer;
    using SQLServer.Contracts;

    using XML;

    public class XmlReportsHandler
    {
        private readonly IMongoDbData mongoData;

        private readonly ISqlServerData msSqlData;

        private readonly Lazy<MsSqlReportsFetcher> msSqlReportsFetcher = new Lazy<MsSqlReportsFetcher>();

        private readonly IXmlData xmlData;

        public XmlReportsHandler()
            : this(new XmlData(), new SqlServerData(), new MongoDbData())
        {
        }

        public XmlReportsHandler(
            IXmlData xmlDataToUse,
            ISqlServerData msSqlDataToUse,
            IMongoDbData mongoDbDataToUse)
        {
            this.xmlData = xmlDataToUse;
            this.msSqlData = msSqlDataToUse;
            this.mongoData = mongoDbDataToUse;
        }

        public void Save()
        {
            var vendorExpenses = this.xmlData.GetAllVendorExpenses();

            Console.WriteLine("Adding vendor expenses from XML to MongoDB...");
            this.mongoData.SaveExpenses(vendorExpenses);

            Console.WriteLine("Adding vendor expenses from XML to SQL Express...");
            if (this.msSqlData.VendorExpenses.GetById(1) != null)
            {
                Console.WriteLine("Data already exists - aborting...");
                return;
            }

            var allVendors = this.msSqlData.Vendors.All().ToDictionary(v => v.Name, v => v.Id);
            foreach (var expense in vendorExpenses)
            {
                expense.VendorId = allVendors[expense.VendorName];

                this.msSqlData.VendorExpenses.Add(expense);
            }

            this.msSqlData.SaveChanges();
        }

        public void Generate()
        {
            Console.WriteLine("Generating XML reports...");

            var locationsReport = this.msSqlReportsFetcher.Value.GetAllLocationsReport().ToList();

            this.xmlData.GenerateAllLocationsReport(locationsReport);
        }
    }
}