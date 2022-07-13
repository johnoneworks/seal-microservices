using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    // This acts as the data layer (the actual DB)
    public class CatalogContext : ICatalogContext
    {
        // this is .net core dependency injection
        // will retrieve the configuration in ./appsettings.json
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            // Seed the database, this will make the database consistent
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
