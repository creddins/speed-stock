using speed_stock.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


namespace speed_stock.Services
{
    public class InventoryService
    {
        private readonly IMongoCollection<Inventory> _inventory;

        public InventoryService(IInventoryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _inventory = database.GetCollection<Inventory>(settings.CollectionName);
        }

        public List<Inventory> Get() =>
            _inventory.Find(inventory => true).ToList();

        public Inventory Get(string id) =>
            _inventory.Find<Inventory>(inventory => inventory.Id == id).FirstOrDefault();

        public Inventory Create(Inventory inventory)
        {
            _inventory.InsertOne(inventory);
            return inventory;
        }

        public void Update(string id, Inventory inventoryIn) =>
            _inventory.ReplaceOne(inventory => inventory.Id == id, inventoryIn);

        public void Remove(Inventory inventoryIn) =>
            _inventory.DeleteOne(inventory => inventory.Id == inventoryIn.Id);

        public void Remove(string id) => 
            _inventory.DeleteOne(inventory => inventory.Id == id);
    }
}