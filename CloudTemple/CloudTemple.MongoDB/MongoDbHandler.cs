namespace CloudTemple.MongoDB
{
    using System;
    using System.Collections.Generic;

    using global::MongoDB.Driver;

    public class MongoDbHandler
    {
        private readonly Lazy<MongoDatabase> database = new Lazy<MongoDatabase>(CreateConnection);

        public void ReadCollection<T>(string collectionName, Action<T> action)
        {
            var cursor = this.database.Value.GetCollection(collectionName).FindAllAs<T>();

            foreach (var category in cursor)
            {
                action(category);
            }
        }

        public void WriteCollection<T>(string collectionName, IEnumerable<T> collectionItems)
        {
            var collection = this.database.Value.GetCollection<T>(collectionName);

            foreach (var item in collectionItems)
            {
                collection.Insert(item);
            }
        }

        private static MongoDatabase CreateConnection()
        {
            // Create server settings to pass connection string, timeout, etc.
            var settings = new MongoServerSettings
                               {
                                   Server =
                                       new MongoServerAddress(
                                       MongoDbSettings.Default.MongoDbAddress,
                                       int.Parse(MongoDbSettings.Default.MongoDbPort))
                               };

            // Create server object to communicate with our server
            var server = new MongoServer(settings);

            // Get our database instance to reach collections and data
            var database = server.GetDatabase(MongoDbSettings.Default.MongoDbDefaultDatabase);

            return database;
        }
    }
}