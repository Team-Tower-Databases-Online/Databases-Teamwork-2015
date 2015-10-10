namespace CloudTemple.Common
{
    using System;
    using System.IO;

    public static class Constants
    {
        private const string ReportsPath = "../../../../";
        public const string SampleReportsZipFilePath = ReportsPath + "Reports/Sales-Reports.zip";
        public const string AggregatedSaleReportPdfPath = ReportsPath + "Reports/PDF_Reports";
        public const string ExtractedXmlReportsPath = ReportsPath + "Reports/XML_Reports/";
        public const string ExtractedExcelReportsPath = ReportsPath + "Reports/Excel_Reports/";
        public const string XmlFilePath = ReportsPath + "Reports/Vendors-Expenses.xml";
        public const string XmlReportName = "xml-report.xml";
        public const string ExcelReportName = "excel-report.xlsx";
        public const string PdfReportName = "/Aggrerated-Sales-Report.pdf";
        public const string ExcelFileExtensionPattern = "*.xls";
        public const string FontPath = "../../OpenSans-Regular.ttf";
        public const string JsonProductsReportsPath = ReportsPath + "Reports/Json_Reports";
        public const string DatabaseName = "CloudTemple";
        public const int Indentation = 4;

        public static string ReportsDirectoryPath
        {
            get
            {
                try
                {
                    return Directory.GetParent(Directory.GetCurrentDirectory())
                        .Parent
                        .Parent
                        .Parent.FullName + "\\Reports";
                }
                catch (Exception)
                {
                    return Directory.GetCurrentDirectory();
                }
            }
        }

        public static string FormatWithCurrency(this decimal text)
        {
            return $"{text:C}";
        }
    }
}