namespace CloudTemple.ReportsModels
{
    using System.Collections.Generic;

    public class FinancialResultReport
    {
        public IEnumerable<FinancialResultReportEntry> Report { get; set; }
    }
}