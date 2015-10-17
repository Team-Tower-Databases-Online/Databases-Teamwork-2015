namespace CloudTemple.SQLite
{
    using System.Collections.Generic;

    using ReportsModels;

    public class SqLiteData : ISqLiteData
    {
        private readonly ISqLiteProductTaxesRepository productTaxesRepository;

        public SqLiteData(ISqLiteProductTaxesRepository productTaxesRepository)
        {
            this.productTaxesRepository = productTaxesRepository;
        }

        public SqLiteData()
            : this(new SqLiteProductTaxesRepository())
        {
        }

        public IEnumerable<ProductTax> GetAllProducTaxes()
        {
            return this.productTaxesRepository.All();
        }

        public void AddProductTax(ProductTax productTax)
        {
            this.productTaxesRepository.AddProductTax(productTax);
        }

        public void Remove(ProductTax productTax)
        {
            this.productTaxesRepository.Delete(productTax);
        }

        public void SaveChanges()
        {
            this.productTaxesRepository.SaveChanges();
        }
    }
}