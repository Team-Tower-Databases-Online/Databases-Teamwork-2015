namespace CloudTemple.Logic
{
    using System;

    using JSON;

    public class JsonReportsGenerator
    {
        private readonly Lazy<JsonHandler> jsonHandler = new Lazy<JsonHandler>();

        private readonly Lazy<MsSqlReportsFetcher> msSqlReportsFetcher = new Lazy<MsSqlReportsFetcher>();

        public void Generate()
        {
            Console.WriteLine("Generating JSON reports...");

            var allProductsInformation = this.msSqlReportsFetcher.Value.GetAllProductInformations();

            foreach (var report in allProductsInformation)
            {
                this.jsonHandler.Value.GenerateJsonFileReport(report);
            }
        }
    }
}