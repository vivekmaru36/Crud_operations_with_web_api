using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Crud_app_with_mongo.Model
{
    public class LoginCheckRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        [BsonElement("rfid")]
        public string rfid { get; set; }

        [Required]
        [BsonElement("password")]
        public string password { get; set; }
    }

    public class LoginCheckResponse
    {
        public bool isSuccess { get; set; }
        public string Message { get; set; }
    }
}
