using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Crud_app_with_mongo.Model
{
    public class Register_Teacher_Request
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }

        public string CreatedDate { get; set; }

        public string UpdatedDate { get; set; }

        [Required]
        [BsonElement("firstName")]
        public string firstName { get; set; }

        /*[Required]
        [BsonElement("lastName")]
        public string lastName { get; set; }
*/
        [Required]
        [BsonElement("email")]
        public string email { get; set; }

        [Required]
        [BsonElement("current_Year")]
        public string current_Year { get; set; }

        /*[Required]
        [BsonElement("final_Year")]
        public string final_Year { get; set; }*/

        [Required]
        [BsonElement("rfidno")]
        public string rfidno { get; set; }

        // password field
        [Required]
        [BsonElement("password")]
        public string password { get; set; }

        // Course field
        [Required]
        [BsonElement("Course")]
        public string Course { get; set; }
    }
    public class Register_Teacher_Response
    {
        public bool isSuccess { get; set; }
        public string Message { get; set; }
    }
}
