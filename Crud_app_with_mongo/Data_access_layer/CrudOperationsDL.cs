using Amazon.Runtime.Internal;
using Crud_app_with_mongo.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Crud_app_with_mongo.Data_access_layer
{
    public class CrudOperationsDL : ICrudOperationsDL
    {
        private readonly IConfiguration _configuration;
     
        // for mongo client
        private readonly MongoClient _mongoClient;

        private readonly IMongoCollection<InsertRecordRequest> _monngoCollection;

        // For Rfid Mongo

        // For Regform
        private readonly IMongoCollection<Regestration_Details_Request> _monngoCollection_1;

        public CrudOperationsDL(IConfiguration configuration) { 
            _configuration = configuration;
            _mongoClient=new MongoClient(_configuration["Databasesettings:ConnectionString"]);

            // providing the database name and collection name
            var _MongoDatabase = _mongoClient.GetDatabase(_configuration["Databasesettings:DatabaseName"]);


            // instance for collections
            _monngoCollection = _MongoDatabase.GetCollection<InsertRecordRequest>(_configuration["Databasesettings:CollectionName"]);


            // Connection Settings For Rfid

            // Reg form
            // providing the database name and collection name for reg form
            var _MongoDatabase_1 = _mongoClient.GetDatabase(_configuration["Databasesettings:DatabaseName_1"]);

            _monngoCollection_1 = _MongoDatabase_1.GetCollection<Regestration_Details_Request>(_configuration["Databasesettings:CollectionName_1"]);

        }

        public async Task<InsertRecordResponse> InsertRecord(InsertRecordRequest request)
        {
            // below is default code when implemented
            // throw new NotImplementedException();

            InsertRecordResponse response = new InsertRecordResponse();
            response.IsSuccess = true;
            response.Message = "Data succesfully Inserted";

            try
            {

                request.CreatedDate = DateTime.Now.ToString();
                request.UpdatedDate = string.Empty;

                await _monngoCollection.InsertOneAsync(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message= "Exception Occured : "+ex.Message;
            }
            return response;

        }
        public async Task<GetAllRecordRepsonse> GetAllRecord()
        {

            GetAllRecordRepsonse response = new GetAllRecordRepsonse();
            response.IsSuccess= true;
            response.Message = "Data Fetch succesfully";

            try {

                response.data = new List<InsertRecordRequest>();
                response.data = await _monngoCollection.Find(x => true).ToListAsync();
                if (response.data.Count==0)
                {
                    response.Message = "No records found for get";
                }
            }
            catch (Exception ex) { 
                response.IsSuccess = false;
                response.Message = "Exception Occurs on get : " + ex.Message;
            }
            return response;
        }

        public async Task<GetRecordByIDResponse> GetRecordByID(string ID)
        {
            GetRecordByIDResponse response = new GetRecordByIDResponse();
            response.IsSuccess = true;
            response.Message = "Fetched data successfully by ID";

            try {
                response.data=await _monngoCollection.Find(x=>(x.Id==ID)).FirstOrDefaultAsync();
                if (response.data == null)
                {
                    response.Message = "Invalid Id Please enter valid Id";
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message= "Exception occurs for get by ID : "+ex.Message;
            }
            return response;
        }

        public async Task<GetRecordByNameResponse> GetRecordByName(string Name)
        {
            GetRecordByNameResponse response = new GetRecordByNameResponse();
            response.IsSuccess = true;
            response.Message = "Fetched data successfully by Name";

            try
            {
                // since it is list so allocate data first
                response.data=new List<InsertRecordRequest>();

                response.data = await _monngoCollection.Find(x => (x.FirstName == Name)||(x.LastName==Name)).ToListAsync();
                if (response.data.Count == 0)
                {
                    response.Message = "Invalid Name Please enter valid Name ";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception occurs for get by Name : " + ex.Message;
            }
            return response;
        }

        // update using id
        public async Task<UpdateRecordbyIdResponse> UpdateRecordById(InsertRecordRequest request)
        {
            UpdateRecordbyIdResponse response = new UpdateRecordbyIdResponse();
            response.IsSuccess = true;
            response.Message = "Updated records successfully by id";
            try {

                // to get created id from db using getrecordbyid
                GetRecordByIDResponse response1 = await GetRecordByID(request.Id);
                request.CreatedDate = response1.data.CreatedDate;

                // to update the current id
                request.UpdatedDate=DateTime.Now.ToString();

                var Result = await _monngoCollection.ReplaceOneAsync(x => x.Id == request.Id, request);

                if (!Result.IsAcknowledged) {
                    response.Message = "Erorr in updating records since id not found ";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error occured in updating records by id : " + ex.Message;
            }

            return response;
        }

        // updating just salary by using patch
        public async Task<UpdateSalaryByIdResponse> UpdateSalaryById(UpdateSalaryByIdRequest request)
        {
            UpdateSalaryByIdResponse response = new UpdateSalaryByIdResponse();
            response.IsSuccess = true;
            response.Messages = "Updated records successfully by id";
            try
            {
                var Filter = new BsonDocument().Add("Salary", request.Salary).Add("UpdatedDate", DateTime.Now.ToString());

                // query to patch
                var UpdatedDate = new BsonDocument("$set", Filter);

                var Result = await _monngoCollection.UpdateOneAsync(x => x.Id == request.Id, UpdatedDate);

                if (!Result.IsAcknowledged)
                {
                    response.Messages = "Erorr in updating salary only , since id not found ";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Messages = "Error occured in updating salary only by id : " + ex.Message;
            }
            return response;
        }

        // delteting record by using id
        public async Task<DeleteRecordByIdResponse> DeleteRecordById(DeleteRecordByIdRequest request)
        {
            DeleteRecordByIdResponse response = new DeleteRecordByIdResponse();
            response.IsSuccess = true;
            response.Message = "Record deleted succesfully by using Id ";
            try
            {
                
                var Result = await _monngoCollection.DeleteOneAsync(x => x.Id == request.ID);
                if (!Result.IsAcknowledged)
                {
                    response.Message = "Document not found / record not found , Please enter a valid ID ";
                }

            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error occured in deleting records using Id : " + ex.Message;
            }
            return response;
        }

        public async Task<DeleteAllRecordResponse> DeleteAllRecord()
        {
            DeleteAllRecordResponse response = new DeleteAllRecordResponse();
            response.IsSuccess = true;
            response.Message = "All Records deleted succesfully";
            try
            {
                var Result = await _monngoCollection.DeleteManyAsync(x=>true);
                if (!Result.IsAcknowledged)
                {
                    response.Message = "NO records found to delete ";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error occured in deleting all records: " + ex.Message;
            }
            return response;
        }

        // for rfid
        // dont' forget to add async

        // my apis extended definations of implementations in ICrudOperationsDl.cs

        public async Task<Regestration_Details_Response> RegestrationDetails(Regestration_Details_Request request)
        {
            Regestration_Details_Response response = new Regestration_Details_Response();
            // default value as True
            response.isSuccess = true;
            response.Message = "Regform -> Data inserted succesfully";
            try
            {
                request.CreatedDate = DateTime.Now.ToString();
                request.UpdatedDate = string.Empty;

                await _monngoCollection_1.InsertOneAsync(request);

            }catch(Exception ex) {
                response.isSuccess = false;
                response.Message = "Reg_Dl Exception Occurs : " + ex.Message;
            }

            return response;
        }
    }

}