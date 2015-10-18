namespace CloudTemple.ReportsModels
{
    using System;
    using System.Collections.Generic;

    public class ProductsReport
    {
        public ProductsReport()
        {
            this.Products = new List<ProductsReportEntry>();
        }

        public DateTime Date { get; set; }

        public IEnumerable<ProductsReportEntry> Products { get; set; }
    }
}