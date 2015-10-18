namespace CloudTemple.SQLite.Contracts
{
    using System.Linq;

    using ReportsModels;

    public interface ISqLiteProductTaxesRepository
    {
        void AddProductTax(ProductTax entry);

        void Delete(ProductTax entry);

        IQueryable<ProductTax> All();

        void SaveChanges();
    }
}