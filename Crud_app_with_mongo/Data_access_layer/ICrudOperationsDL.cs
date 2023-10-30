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
    }
}
