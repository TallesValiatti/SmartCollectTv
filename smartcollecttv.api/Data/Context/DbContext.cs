using Microsoft.Azure.Cosmos;

namespace smartcollecttv.api.Data.Context
{
    public class DbContext
    {
        public Container CollectionPoints
        {
            get =>  _database.GetContainer(_collectionPointContainer);
        }
        private Database _database;
        private string _collectionPointContainer;

        public DbContext(
            string connectionString, 
            string databaseName,
            string collectionPointContainer)
        {
            _collectionPointContainer = collectionPointContainer;

            var client = new CosmosClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }
    }
}