namespace CloudTemple.ReportsModels
{
    using System.Collections.Generic;

    public class CategorySalesReport
    {
        public IEnumerable<CategorySalesReportEntry> Report { get; set; }
    }
}