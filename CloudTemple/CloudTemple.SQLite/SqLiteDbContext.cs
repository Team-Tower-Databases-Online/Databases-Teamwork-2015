namespace CloudTemple.SQLite
{
    using System.Data.Entity;

    using ReportsModels;

    public class SqLiteDbContext : DbContext, ISqLiteDbContext
    {
        public SqLiteDbContext()
            : base("SqLiteConnectionString")
        {
            this.Database.CreateIfNotExists();
        }

        public IDbSet<ProductTax> ProductsTaxes { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}