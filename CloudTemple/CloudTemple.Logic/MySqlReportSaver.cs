namespace CloudTemple.Logic
{
    using System;
    using System.Linq;

    using MySQL;
    using MySQL.Models;

    public class MySqlReportSaver
    {
        private readonly Lazy<MsSqlReportsFetcher> msSqlReportsFetcher = new Lazy<MsSqlReportsFetcher>();

        private readonly Lazy<MySqlData> mySqlHandler = new Lazy<MySqlData>();

        public void Save()
        {
            Console.WriteLine("Saving data into MySQL...");

            this.mySqlHandler.Value.DeleteAllReports();

            var allProductsReports =
                this.msSqlReportsFetcher.Value.GetAllProductInformations()
                    .Select(
                        product =>
                        new Salereport
                            {
                                Product_id = product.ProductId,
                                ProductName = product.Name,
                                TotalIncomes = (int)product.Total,
                                TotalQuantitySold = product.Quantity,
                                VendorName = product.Vendor
                            });

            this.mySqlHandler.Value.SaveReports(allProductsReports);
        }
    }
}