using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;


namespace speed_stock.Models
{
    public class Inventory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Item")]
        [JsonProperty("Item")]
        public string Item { get; set; }

        public string Category { get; set; }

        public string PurchaseUnit { get; set; }

        public decimal Price { get; set; }

        public decimal OrderUnit { get; set; }

        public decimal Cost { get; set; }

    }
}