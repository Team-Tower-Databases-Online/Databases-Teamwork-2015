namespace CloudTemple.MongoDB
{
    using global::MongoDB.Driver;
    using Mappings;

    public class MongoDbContext
    {
        private readonly string connectionString;
        private readonly string databaseName;

        public MongoDbContext()
            : this(ConnectionString.Default.MongoDbLocalServer, ConnectionString.Default.MongoDbDefaultDatabase)
        {
        }

        public MongoDbContext(string connectionString, string databaseName)
        {
            this.connectionString = connectionString;
            this.databaseName = databaseName;
        }

        public MongoCollection<CountryMap> Countries
            => this.GetCollection<CountryMap>("Countries");

        public MongoCollection<CityMap> Cities
            => this.GetCollection<CityMap>("Cities");

        public MongoCollection<AddressMap> Addresses
            => this.GetCollection<AddressMap>("Addresses");

        public MongoCollection<ProductMap> Products
            => this.GetCollection<ProductMap>("Products");

        public MongoCollection<ProductTypeMap> ProductTypes
            => this.GetCollection<ProductTypeMap>("ProductTypes");

        public MongoCollection<ManufacturerMap> Manufacturers
            => this.GetCollection<ManufacturerMap>("Manufacturers");

        public MongoCollection<ManufacturerExpenseMap> ManufacturerExpenses
            => this.GetCollection<ManufacturerExpenseMap>("ManufacturerExpenses");

        private MongoCollection<T> GetCollection<T>(string collectionName)
        {
            var database = this.GetDatabase();
            var collection = database.GetCollection<T>(collectionName);
            return collection;
        }

        private MongoDatabase GetDatabase()
        {
            const string host = "127.0.0.1";
            const int port = 27017;
            const string name = "cloudtemple";

            // Create server settings to pass connection string, timeout, etc.
            var settings = new MongoServerSettings { Server = new MongoServerAddress(host, port) };

            // Create server object to communicate with our server
            var server = new MongoServer(settings);

            // Get our database instance to reach collections and data
            var database = server.GetDatabase(name);
            return database;
        }
    }
}