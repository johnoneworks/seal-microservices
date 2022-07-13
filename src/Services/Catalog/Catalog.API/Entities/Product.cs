using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string? Name { get; set; }

        // You can determine if you want to add attributes similar to the above members
        public string? Category { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public string? ImageFile { get; set; }
        public decimal Price { get; set; }

        public Product(string id)
        {
            Id = id;
        }
        
    }
}
