using System.ComponentModel.DataAnnotations;

namespace Crud_app_with_mongo.Model
{
    public class UpdateSalaryByIdRequest
    {
        [Required]
        public string Id {  get; set; }
        [Required]
        public int Salary {  get; set; } 
    }
    public class UpdateSalaryByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Messages { get; set; }
    }

}
