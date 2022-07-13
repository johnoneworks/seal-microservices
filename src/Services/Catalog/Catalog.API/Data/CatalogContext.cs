using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        // this is .net core dependency injection
        // will retrieve the configuration in ./appsettings.json
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        }

        public IMongoCollection<Product> Products => throw new NotImplementedException();
    }
}
