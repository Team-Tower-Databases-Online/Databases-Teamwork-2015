namespace CloudTemple.SQLServer
{
    using System.Data.Entity;

    using Contracts;

    using Migrations;

    using Models;

    public class SqlServerDbContext : DbContext, ISqlServerDbContext
    {
        public SqlServerDbContext()
            : base("CloudTempleDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SqlServerDbContext, Configuration>());
        }

        public IDbSet<VendorExpense> VendorExpenses { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<ProductCategory> Categories { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<ProductDetails> Details { get; set; }

        public IDbSet<Purchase> Purchases { get; set; }

        public IDbSet<PurchaseLocation> Locations { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}