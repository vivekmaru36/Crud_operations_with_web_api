using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Crud_app_with_mongo.Model
{
    public class Regestration_Details_Request
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id {  get; set; }

        public string CreatedDate { get; set; }

        public string UpdatedDate { get; set;}
        
        [Required]
        [BsonElement("firstName")]
        public string firstName { get; set; }

        [Required]
        [BsonElement("lastName")]
        public string lastName { get; set; }

        [Required]
        [BsonElement("email")]
        public string email { get; set; }

        [Required]
        [BsonElement("current_Year")]
        public string current_Year { get; set; }

        [Required]
        [BsonElement("final_Year")]
        public string final_Year { get; set; }

        [Required]
        [BsonElement("rfidno")]
        public string rfidno { get; set; }

    }
    public class Regestration_Details_Response
    {
        public bool isSuccess { get; set; }
        public string Message { get; set; }
    }


    // for making rfid unique in db schema

    /*public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext()
        {
            var connectionString = "mongodb://localhost:27017";
            var databaseName = "Registrationdata";
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);

            // Create a unique index on the "Rfid_no" field
            CreateUniqueIndexOnRfid();
        }

        public IMongoCollection<Regestration_Details_Request> RegistrationDetailsCollection
        {
            get
            {
                return _database.GetCollection<Regestration_Details_Request>("RegDetails"); // Use the collection name from your settings
            }
        }

        private void CreateUniqueIndexOnRfid()
        {
            var indexKeys = Builders<Regestration_Details_Request>.IndexKeys.Ascending(r => r.Rfid_no);
            var uniqueIndexModel = new CreateIndexModel<Regestration_Details_Request>(indexKeys, new CreateIndexOptions { Unique = true });

            RegistrationDetailsCollection.Indexes.CreateOne(uniqueIndexModel);
        }
    }*/

}
