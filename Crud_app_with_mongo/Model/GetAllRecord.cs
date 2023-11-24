namespace Crud_app_with_mongo.Model
{
    public class GetAllRecordRepsonse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<InsertRecordRequest> data { get; set; }

    }
}
