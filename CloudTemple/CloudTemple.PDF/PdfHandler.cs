namespace CloudTemple.PDF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ReportsModels;

    public class PdfHandler
    {
        private readonly Lazy<PdfWriter> pdfWriter = new Lazy<PdfWriter>();

        public void GenerateAllProductsInformation(ProductsReport productInformations)
        {
            this.pdfWriter.Value.GenerateReport(productInformations, "All products Report");
        }

        public void GenerateAllProductsReportForDate(ProductsReport report)
        {
            var date = report.Date.ToString("dd MMM yyyy");
            this.pdfWriter.Value.GenerateReport(report, "All products Report for " + date);
        }

        public void GenerateProductInfoForLocations(IEnumerable<ProductsReport> reports)
        {
            var reportsAsOne = new ProductsReport
                                   {
                                       Products =
                                           reports.Select(
                                               x =>
                                               new ProductsReportEntry
                                                   {
                                                       Location =
                                                           x.Products.Min(
                                                               p => p.Location),
                                                       Name =
                                                           x.Products.Min(
                                                               p => p.Name),
                                                       Price =
                                                           x.Products.Min(
                                                               p => p.Price),
                                                       ProductId =
                                                           x.Products.Min(
                                                               p => p.ProductId),
                                                       Vendor =
                                                           x.Products.Min(
                                                               p => p.Vendor),
                                                       Quantity =
                                                           x.Products.Sum(
                                                               p => p.Quantity)
                                                   })
                                   };

            this.pdfWriter.Value.GenerateReport(
                reportsAsOne,
                "Single Product " + reportsAsOne.Products.First().Name + " Report by Locations");
        }

        public void GenerateLocationReportForDate(ProductsReport report)
        {
            var date = report.Date.ToString("dd MMM yyyy");
            this.pdfWriter.Value.GenerateReport(
                report,
                "All products Report for Realm " + report.Products.First().Location + " at " + date);
        }

        public void GenerateTotalLocationReport(ProductsReport report)
        {
            this.pdfWriter.Value.GenerateReport(
                report,
                "All products Report for Realm " + report.Products.First().Location);
        }
    }
}