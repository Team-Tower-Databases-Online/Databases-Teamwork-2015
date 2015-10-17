namespace CloudTemple.SQLite
{
    using System.Data.Entity;

    using ReportsModels;

    public interface ISqLiteDbContext
    {
        IDbSet<ProductTax> ProductsTaxes { get; set; }

        void SaveChanges();
    }
}