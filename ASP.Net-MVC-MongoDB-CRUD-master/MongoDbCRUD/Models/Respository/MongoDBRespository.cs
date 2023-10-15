using MongoDB.Driver;

namespace MongoDbCRUD.Models.Respository
{
    public class MongoDBRespository
    {
        // MongoClient is used to connect to the MongoDB server.
        public MongoClient client;

        // IMongoDatabase interface is used for database transactions.
        public IMongoDatabase db;

        public MongoDBRespository()
        {
            // Here, we establish a connection to the MongoDB server at the specified address.
            this.client = new MongoClient("mongodb://localhost:27017");

            // If the specified database doesn't exist, a new one will be created with the name "ExampleMongoDB."
            this.db = this.client.GetDatabase("ExampleMongoDB");
        }
    }
}
