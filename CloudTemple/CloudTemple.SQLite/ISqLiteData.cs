namespace CloudTemple.SQLite
{
    using System.Collections.Generic;

    using ReportsModels;

    public interface ISqLiteData
    {
        IEnumerable<ProductTax> GetAllProducTaxes();

        void AddProductTax(ProductTax productTax);

        void Remove(ProductTax productTax);

        void SaveChanges();
    }
}