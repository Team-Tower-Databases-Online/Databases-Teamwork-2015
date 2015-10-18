namespace CloudTemple.SQLite
{
    using System.Data.Entity;

    using Contracts;

    using ReportsModels;

    public class SqLiteDbContext : DbContext, ISqLiteDbContext
    {
        public SqLiteDbContext()
            : base("SqLiteDb")
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