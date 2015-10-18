namespace CloudTemple.Logic
{
    using System;
    using System.Linq;

    using PDF;

    using ReportsModels;

    public class PdfReportGenerator
    {
        private readonly Lazy<MsSqlReportsFetcher> msSqlReportsFetcher = new Lazy<MsSqlReportsFetcher>();

        private readonly Lazy<PdfHandler> pdfHandler = new Lazy<PdfHandler>();

        public void Generate()
        {
            Console.WriteLine("Generating PDF reports...");

            this.GenerateAllProductsInformation();
            //this.GenerateAllProductsReportForDate(new DateTime(2015, 1, 1));

            this.GenerateProductInfoForLocations("Black & Decker Heat Gun");

            //this.GenerateLocationReportForDate(1, new DateTime(2015, 1, 1));
            //this.GenerateTotalLocationReport(1);
        }

        public void GenerateAllProductsInformation()
        {
            var reports = this.msSqlReportsFetcher.Value.GetAllProductInformations();
            this.pdfHandler.Value.GenerateAllProductsInformation(new ProductsReport { Products = reports });
        }

        public void GenerateAllProductsReportForDate(DateTime date)
        {
            var reports = this.msSqlReportsFetcher.Value.GetAllProductsReportForDate(date);
            this.pdfHandler.Value.GenerateAllProductsReportForDate(reports);
        }

        public void GenerateProductInfoForLocations(int productId)
        {
            var reports = this.msSqlReportsFetcher.Value.GetProductInformationForLocations(productId);
            this.pdfHandler.Value.GenerateProductInfoForLocations(reports);
        }

        public void GenerateProductInfoForLocations(string productName)
        {
            var reports = this.msSqlReportsFetcher.Value.GetProductInformationForLocations(productName).ToList();
            this.pdfHandler.Value.GenerateProductInfoForLocations(reports);
        }

        public void GenerateLocationReportForDate(int locationId, DateTime date)
        {
            var reports = this.msSqlReportsFetcher.Value.GetLocationReportForDate(locationId, date);
            this.pdfHandler.Value.GenerateLocationReportForDate(reports);
        }

        public void GenerateLocationReportForDate(string locationName, DateTime date)
        {
            var reports = this.msSqlReportsFetcher.Value.GetLocationReportForDate(locationName, date);
            this.pdfHandler.Value.GenerateLocationReportForDate(reports);
        }

        public void GenerateTotalLocationReport(int locationId)
        {
            var reports = this.msSqlReportsFetcher.Value.GetTotalLocationReport(locationId);
            this.pdfHandler.Value.GenerateTotalLocationReport(reports);
        }

        public void GenerateTotalLocationReport(string locationName)
        {
            var reports = this.msSqlReportsFetcher.Value.GetTotalLocationReport(locationName);
            this.pdfHandler.Value.GenerateTotalLocationReport(reports);
        }
    }
}