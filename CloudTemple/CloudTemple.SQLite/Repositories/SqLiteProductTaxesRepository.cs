namespace CloudTemple.SQLite.Repositories
{
    using System.Linq;

    using Contracts;

    using ReportsModels;

    public class SqLiteProductTaxesRepository : ISqLiteProductTaxesRepository
    {
        private readonly ISqLiteDbContext context;

        public SqLiteProductTaxesRepository(ISqLiteDbContext context)
        {
            this.context = context;
        }

        public SqLiteProductTaxesRepository()
            : this(new SqLiteDbContext())
        {
        }

        public void AddProductTax(ProductTax entry)
        {
            this.context.ProductsTaxes.Add(entry);
        }

        public void Delete(ProductTax entry)
        {
            this.context.ProductsTaxes.Remove(entry);
        }

        public IQueryable<ProductTax> All()
        {
            return this.context.ProductsTaxes;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}