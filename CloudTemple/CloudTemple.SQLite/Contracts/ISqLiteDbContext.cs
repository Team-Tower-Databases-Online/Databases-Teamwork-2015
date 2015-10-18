namespace CloudTemple.SQLite.Contracts
{
    using System.Data.Entity;

    using ReportsModels;

    public interface ISqLiteDbContext
    {
        IDbSet<ProductTax> ProductsTaxes { get; set; }

        void SaveChanges();
    }
}