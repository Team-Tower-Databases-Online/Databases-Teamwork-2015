namespace CloudTemple.MongoDB.Contracts
{
    using global::MongoDB.Driver;
    using Mappings;

    public interface IMongoDbContext
    {
        MongoCollection<CountryMap> Countries { get; }

        MongoCollection<CityMap> Cities { get; }

        MongoCollection<AddressMap> Addresses { get; }

        MongoCollection<ProductMap> Products { get; }

        MongoCollection<ProductTypeMap> ProductTypes { get; }

        MongoCollection<ManufacturerMap> Manufacturers { get; }

        MongoCollection<ManufacturerExpenseMap> ManufacturerExpenses { get; }
    }
}