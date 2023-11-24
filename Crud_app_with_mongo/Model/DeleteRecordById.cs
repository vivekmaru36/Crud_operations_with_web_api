using System.ComponentModel.DataAnnotations;

namespace Crud_app_with_mongo.Model
{
    public class DeleteRecordByIdRequest
    {
        [Required]
        public string ID { get; set; }
        

    }
    public class DeleteRecordByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message {  get; set; }
    }
}
