namespace Crud_app_with_mongo.Model
{
    public class GetRecordByIDResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public InsertRecordRequest data { get; set; }
    }

    public class GetRecordByNameResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<InsertRecordRequest> data { get; set; }
    }
}

