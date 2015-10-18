namespace CloudTemple.ConsoleClient
{
    using Logic;

    internal class Program
    {
        private static void Main()
        {
            // TODO: Improve logic by implementing factory design pattern
            // Preparation
            var dataSeeder = new DataSeeder();
            dataSeeder.Seed();

            // Problem 1
            var excelReportsLoader = new ExcelReportsLoader();
            excelReportsLoader.Load();

            // Problem 2
            var pdfReportGenerator = new PdfReportGenerator();
            pdfReportGenerator.Generate();

            // Problem 3
            var xmlReportsHandler = new XmlReportsGenerator();
            xmlReportsHandler.Generate();
        }
    }
}