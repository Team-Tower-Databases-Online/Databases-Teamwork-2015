namespace CloudTemple.ConsoleClient
{
    using Logic;

    internal class Program
    {
        private static void Main()
        {
            // TODO: Improve logic by implementing factory design pattern
            // Problem 1
            var dataSeeder = new DataSeeder();
            dataSeeder.Seed();

            // Problem 2
            var excelReportsLoader = new ExcelReportsLoader();
            excelReportsLoader.Load();
        }
    }
}