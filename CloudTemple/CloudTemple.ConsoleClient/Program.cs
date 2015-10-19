namespace CloudTemple.ConsoleClient
{
    using Logic;

    internal class Program
    {
        private static readonly DataSeeder DataSeeder = new DataSeeder();

        private static readonly ExcelReportsLoader ExcelReportsLoader = new ExcelReportsLoader();

        private static readonly PdfReportGenerator PdfReportGenerator = new PdfReportGenerator();

        private static readonly XmlReportsHandler XmlReportsHandler = new XmlReportsHandler();

        private static readonly JsonReportsGenerator JsonReportsGenerator = new JsonReportsGenerator();

        private static readonly MySqlReportSaver MySqlReportSaver = new MySqlReportSaver();

        private static void Main()
        {
            // TODO: Improve logic by implementing factory design pattern
            // Preparation
            DataSeeder.Seed();

            // Problem 1
            ExcelReportsLoader.Load();

            // Problem 2
            PdfReportGenerator.Generate();

            // Problem 3
            XmlReportsHandler.Generate();

            // Problem 4.1
            JsonReportsGenerator.Generate();

            // Problem 4.2
            //MySqlReportSaver.Save();

            // Problem 5
            XmlReportsHandler.Save();
        }
    }
}