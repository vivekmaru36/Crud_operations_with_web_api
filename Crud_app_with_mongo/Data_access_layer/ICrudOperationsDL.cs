using Crud_app_with_mongo.Model;

namespace Crud_app_with_mongo.Data_access_layer
{
    public interface ICrudOperationsDL
    {
        public Task<InsertRecordResponse> InsertRecord(InsertRecordRequest request);
        public Task<GetAllRecordRepsonse> GetAllRecord();
        public Task<GetRecordByIDResponse> GetRecordByID(string ID);
        public Task<GetRecordByNameResponse> GetRecordByName(string Name);
        public Task<UpdateRecordbyIdResponse> UpdateRecordById(InsertRecordRequest request);
        public Task<UpdateSalaryByIdResponse> UpdateSalaryById(UpdateSalaryByIdRequest request);
        public Task<DeleteRecordByIdResponse> DeleteRecordById(DeleteRecordByIdRequest request);
        public Task<DeleteAllRecordResponse> DeleteAllRecord();

        // my apis

        // api for reg
        public Task<Regestration_Details_Response> RegestrationDetails(Regestration_Details_Request request);

        //api for login
        public Task<LoginCheckResponse> LoginCheck(LoginCheckRequest loginRequest);


        // api for fetching based on rfid
        public Task<GetRecordByRfidResponse> GetRecordByRfid(string rfid);

        // api for reg for teacher
        public Task<Register_Teacher_Response> Register_Teacher(Register_Teacher_Request request);

    }
}
