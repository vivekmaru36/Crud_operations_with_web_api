using Crud_app_with_mongo.Model;
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

        public CrudOperationsDL(IConfiguration configuration) { 
            _configuration = configuration;
            _mongoClient=new MongoClient(_configuration["Databasesettings:ConnectionString"]);

            // providing the database name and collection name
            var _MongoDatabase = _mongoClient.GetDatabase(_configuration["Databasesettings:DatabaseName"]);

            // instance for collections
            _monngoCollection = _MongoDatabase.GetCollection<InsertRecordRequest>(_configuration["Databasesettings:CollectionName"]);

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
    }

}
