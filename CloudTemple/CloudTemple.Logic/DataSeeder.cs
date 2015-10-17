namespace CloudTemple.Logic
{
    using System;

    using Excel;

    using MongoDB;

    using SQLite;

    public class DataSeeder
    {
        public void Seed()
        {
            Console.WriteLine("Seeding mongo data...");
            var mongoDataSeeder = new MongoDataSeeder();
            mongoDataSeeder.Seed();

            Console.WriteLine("Seeding excel data...");
            var excelZippedDataSeeder = new ExcelZippedDataSeeder();
            excelZippedDataSeeder.Seed(3);

            Console.WriteLine("Seeding SQLite data...");
            var sqLiteDataSeeder = new SqLiteDataSeeder();
            sqLiteDataSeeder.Seed();
        }
    }
}