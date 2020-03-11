namespace speed_stock.Models
{
    public class InventoryDatabaseSettings : IInventoryDatabaseSettings
    {
        public string CollectionName { get; set; }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IInventoryDatabaseSettings
    {
        string CollectionName { get; set; }

        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}