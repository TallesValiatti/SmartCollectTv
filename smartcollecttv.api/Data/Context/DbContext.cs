using Microsoft.Azure.Cosmos;

namespace smartcollecttv.api.Data.Context
{
    public class DbContext
    {
        public Container CollectionPoints
        {
            get =>  _database.GetContainer(_collectionPointContainer);
        }

        public Container Drivers
        {
            get =>  _database.GetContainer(_driverContainer);
        }

        public Container IotSensors
        {
            get =>  _database.GetContainer(_iotSensorContainer);
        }

        public Container Routes
        {
            get =>  _database.GetContainer(_routesContainer);
        }

        public Container Vehicles
        {
            get =>  _database.GetContainer(_vehicleContainer);
        }

        private Database _database;
        private string _collectionPointContainer;
        private string _driverContainer;
        private string _iotSensorContainer;
        private string _routesContainer;
        private string _vehicleContainer;

        public DbContext(
            string connectionString, 
            string databaseName,
            string collectionPointContainer,
            string driverContainer,
            string iotSensorContainer,
            string routesContainer,
            string vehicleContainer)
        {
            _collectionPointContainer = collectionPointContainer;
            _driverContainer = driverContainer;
            _iotSensorContainer = iotSensorContainer;
            _routesContainer = routesContainer;
            _vehicleContainer = vehicleContainer;
            
            var client = new CosmosClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }
    }
}