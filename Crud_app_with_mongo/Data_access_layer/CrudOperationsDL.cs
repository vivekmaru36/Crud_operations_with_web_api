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
    }
}
