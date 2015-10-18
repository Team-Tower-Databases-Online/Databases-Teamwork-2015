namespace CloudTemple.MongoDB.Contracts
{
    using System.Collections.Generic;

    using Models;

    public interface IMongoDbData
    {
        ICollection<Product> GetAllProducts();

        ICollection<ProductDetails> GetAllProductDetails();

        ICollection<ProductCategory> GetAllProductCategories();

        ICollection<Vendor> GetAllVendors();

        void SaveExpenses(IEnumerable<VendorExpense> allExpenses);
    }
}