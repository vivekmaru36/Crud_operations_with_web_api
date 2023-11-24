using System.ComponentModel.DataAnnotations;

namespace Crud_app_with_mongo.Model
{
    
    public class UpdateRecordbyIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
