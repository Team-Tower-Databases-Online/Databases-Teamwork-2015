namespace CloudTemple.SQLite
{
    using System;

    using Excel;

    using ReportsModels;

    public class SqLiteDataSeeder
    {
        private static readonly Random Random = new Random();

        public void Seed()
        {
            var data = new SqLiteData();
            var oldItems = data.GetAllProducTaxes();
            foreach (var oldItem in oldItems)
            {
                data.Remove(oldItem);
            }

            data.SaveChanges();

            var excelHander = new ExcelXlsHandler();
            excelHander.ReadInitialDataFile(
                "Products$",
                product =>
                {
                    data.AddProductTax(
                        new ProductTax
                        {
                            ProductName = product["Product Name"].ToString(),
                            Amount = Random.NextDouble() * Random.Next(100, 200)
                        });
                });

            data.SaveChanges();
        }
    }
}