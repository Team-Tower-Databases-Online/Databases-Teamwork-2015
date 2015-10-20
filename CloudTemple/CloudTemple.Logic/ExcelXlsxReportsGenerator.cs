namespace CloudTemple.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Excel;

    using Models;

    using MySQL;

    using ReportsModels;

    using SQLite;

    public class ExcelXlsxReportsGenerator
    {
        private readonly Lazy<MsSqlReportsFetcher> msSqlFetcher = new Lazy<MsSqlReportsFetcher>();

        private readonly Lazy<MySqlData> mySqlData = new Lazy<MySqlData>();

        private readonly Lazy<SqLiteData> sqliteData = new Lazy<SqLiteData>();

        private readonly Lazy<ExcelXlsxHandler> xlsxHandler = new Lazy<ExcelXlsxHandler>();

        public void Generate()
        {
            Console.WriteLine("Generating Excel reports...");

            this.GenerateVendorsFinancialResultReport();

            this.GenerateSalesPerCategoryReport();
        }

        public void GenerateVendorsFinancialResultReport()
        {
            var random = new Random();
            var salesReport = this.mySqlData.Value.LoadReports();
            var productsTaxes = this.sqliteData.Value.GetAllProducTaxes().ToList();
            var vendorsExpenses =
                salesReport.Select(
                    sr => new VendorExpense { VendorName = sr.VendorName, Ammount = 10 * random.Next(10, 30) });
            var salesJoinedWithTaxesGroupedByVendor =
                salesReport.Join(
                    productsTaxes,
                    s => s.ProductName,
                    pt => pt.ProductName,
                    (s, pt) =>
                    new
                    {
                        s.VendorName,
                        TotalIncome = s.TotalIncomes,
                        TotalIncomeWithTax = s.TotalIncomes * (pt.Amount / 100)
                    })
                           .GroupBy(s => s.VendorName)
                           .Select(
                               sg =>
                               new
                               {
                                   VendorName = sg.Key,
                                   TotalIncomes = sg.Sum(s => s.TotalIncome),
                                   TotalIncomeWithTax = sg.Sum(s => s.TotalIncomeWithTax)
                               })
                           .ToList();
            var vendorFinancialInfoJoinedWithExpenses =
                salesJoinedWithTaxesGroupedByVendor.Join(
                    vendorsExpenses,
                    f => f.VendorName,
                    e => e.VendorName,
                    (f, e) => new { f.VendorName, f.TotalIncomes, f.TotalIncomeWithTax, Expenses = e.Ammount })
                                                   .GroupBy(fg => fg.VendorName)
                                                   .Select(
                                                       fg =>
                                                       new
                                                       {
                                                           VendorName = fg.Key,
                                                           TotalIncomes = fg.Sum(f => f.TotalIncomes),
                                                           TotalIncomeWithTax = fg.Sum(f => f.TotalIncomeWithTax),
                                                           Expenses = fg.Sum(f => f.Expenses)
                                                       })
                                                   .ToList();
            var reportEntries = new LinkedList<FinancialResultReportEntry>();
            foreach (var row in vendorFinancialInfoJoinedWithExpenses.ToList())
            {
                var reportRecord = new FinancialResultReportEntry
                {
                    VendorName = row.VendorName,
                    Incomes = row.TotalIncomes,
                    Expenses = row.Expenses,
                    Taxes = (decimal)row.TotalIncomeWithTax
                };
                reportRecord.FinancialBalance = reportRecord.Incomes - reportRecord.Taxes - reportRecord.Expenses;
                reportEntries.AddLast(reportRecord);
            }
            var reportData = new FinancialResultReport { Report = reportEntries };
            this.xlsxHandler.Value.GenerateVendorsFinancialResultFile(reportData, "FinancialBalanceResults.xlsx");
        }

        public void GenerateSalesPerCategoryReport()
        {
            var salesPerCategoryReport = this.msSqlFetcher.Value.GetSalesByCategory();
            this.xlsxHandler.Value.GenerateSalesPerCategoryResultFile(salesPerCategoryReport, "SalesPerCategory.xlsx");
        }
    }
}