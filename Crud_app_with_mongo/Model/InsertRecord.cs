using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Crud_app_with_mongo.Model
{
    public class InsertRecordRequest
    {
        // ? --> means it can also be a null value
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string CreatedDate { get; set; }

        public string UpdatedDate { get; set;}

        [Required]
        [BsonElement(elementName:"Name")]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Contact {  get; set; }

        public double Salary {  get; set; }
    }

    // now creating the response body for this

    public class InsertRecordResponse { 
        public bool IsSuccess {  get; set; }
        // the message contains why of issucces like if succes than why if fail than why fail ?
        public string Message {  get; set; } 
    
    }
}
