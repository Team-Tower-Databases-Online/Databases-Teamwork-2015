namespace CloudTemple.Excel
{
    using ClosedXML.Excel;

    using ReportsModels;

    public class ExcelXlsxHandler
    {
        public void GenerateVendorsFinancialResultFile(FinancialResultReport reportData, string fileName)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Financial Balance");

            //Columns
            ws.Cell("B2").Value = "Vendor";
            ws.Cell("C2").Value = "Incomes";
            ws.Cell("D2").Value = "Expenses";
            ws.Cell("E2").Value = "Taxes";
            ws.Cell("F2").Value = "Financial Balance";

            var rowCount = 3;
            foreach (var row in reportData.Report)
            {
                var vendorCell = "B" + rowCount;
                var incomesCell = "C" + rowCount;
                var expensesCell = "D" + rowCount;
                var taxesCell = "E" + rowCount;
                var finacialBalanceCell = "F" + rowCount;

                ws.Cell(vendorCell).Value = row.VendorName;
                ws.Cell(incomesCell).Value = row.Incomes;
                ws.Cell(expensesCell).Value = row.Expenses;
                ws.Cell(taxesCell).Value = row.Taxes;
                ws.Cell(finacialBalanceCell).Value = row.FinancialBalance;

                rowCount++;
            }

            var tableRange = ws.Range("B2", "F" + (rowCount - 1));
            var finBalanceTable = tableRange.CreateTable();
            finBalanceTable.Theme = XLTableTheme.TableStyleMedium16;

            ws.Columns().AdjustToContents();
            wb.SaveAs(ExcelSettings.Default.ExcelReportsDestinationFolder + fileName);
        }

        public void GenerateSalesPerCategoryResultFile(CategorySalesReport reportData, string fileName)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Sales per Category");

            //Columns
            ws.Cell("B2").Value = "Category";
            ws.Cell("C2").Value = "Quantity";
            ws.Cell("D2").Value = "Amount Sold";

            var rowCount = 3;
            foreach (var row in reportData.Report)
            {
                var categoryCell = "B" + rowCount;
                var quantityCell = "C" + rowCount;
                var totalAmountCell = "D" + rowCount;

                ws.Cell(categoryCell).Value = row.Category;
                ws.Cell(quantityCell).Value = row.Quantity;
                ws.Cell(totalAmountCell).Value = row.TotalAmountSold;

                rowCount++;
            }

            var tableRange = ws.Range("B2", "D" + (rowCount - 1));
            var finBalanceTable = tableRange.CreateTable();
            finBalanceTable.Theme = XLTableTheme.TableStyleMedium16;

            ws.Columns().AdjustToContents();
            wb.SaveAs(ExcelSettings.Default.ExcelReportsDestinationFolder + fileName);
        }
    }
}