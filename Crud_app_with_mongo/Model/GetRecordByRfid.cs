namespace Crud_app_with_mongo.Model
{
    public class GetRecordByRfidResponse
    {
        public bool IsSuccess {  get; set; }
        public string Message { get; set; }

        public List<Regestration_Details_Request> data { get; set; }
    }
}
