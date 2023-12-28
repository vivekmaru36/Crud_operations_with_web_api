# RFID Apis :

1) created get api for fetching user based on rfid here :
    https://github.com/vivekmaru36/Crud_operations_with_web_api/blob/master/Crud_app_with_mongo/Data_access_layer/CrudOperationsDL.cs


# Crud_app
Uses asp.net 6.1 and mongo db 

if you encounter any issues follow this link : v=MUO7X0pd8R0&list=PLwxiRZdZ4bZkldxU51cwo5B1xuN9hxvCM&ab_channel=VCoder

// read me its not proper anyways :

1) core web api template
2) create data acces layers folders --> inside that create inerface and class using add class options
3) download mongodb msi package to connect through data
link : https://www.mongodb.com/try/download/community
4) create db using 'use' throuhg terminal than add datacollection in mongodb
5) go to vs studio add dependecy in controller
6) instal mongo db driver Install-Package MongoDB.Driver
important links for above steps : https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-7.0&tabs=visual-studio

7) after adding some things in app settings .json

8) you need to pass the connection string in mongo client in CrudoperationsDl.cs
code inside appsettings.json :
{
  "Databasesettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "CrudOperations",
    "CollectionName": "UserDetails"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
 
code inside CrudOperationsDl.cs we also make new instances of mongoclient :

using Crud_app_with_mongo.Model;
using MongoDB.Driver;

namespace Crud_app_with_mongo.Data_access_layer
{
    public class CrudOperationsDL : ICrudOperationsDL
    {
        private readonly IConfiguration _configuration;
        // for mongo client
        private readonly MongoClient _mongoClient;

        public CrudOperationsDL(IConfiguration configuration) { 
            _configuration = configuration;
            _mongoClient=new MongoClient();
        }

        public async Task<InsertRecordResponse> Insert(InsertRecordRequest request)
        {
            // below is default code when implemented
            // throw new NotImplementedException();

            InsertRecordResponse response = new InsertRecordResponse();

            try
            {

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

9) passing the connection string inside mongoclient()
-->
get the string from appsetting.json

updated code inside CrudOperationsDL.cs :

using Crud_app_with_mongo.Model;
using MongoDB.Driver;

namespace Crud_app_with_mongo.Data_access_layer
{
    public class CrudOperationsDL : ICrudOperationsDL
    {
        private readonly IConfiguration _configuration;
        // for mongo client
        private readonly MongoClient _mongoClient;

        public CrudOperationsDL(IConfiguration configuration) { 
            _configuration = configuration;
            _mongoClient=new MongoClient(_configuration["Databasesettings:ConnectionString"]);
        }

        public async Task<InsertRecordResponse> Insert(InsertRecordRequest request)
        {
            // below is default code when implemented
            // throw new NotImplementedException();

            InsertRecordResponse response = new InsertRecordResponse();

            try
            {

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


10)
crearting var for mongo database name and specifing connection 
with appropriate collection with insertrecordresponse function in insert record

// inside model folders as class
code inside insertrecord.cs :
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Crud_app_with_mongo.Model
{
    public class InsertRecordRequest
    {
        // ? --> means it can also be a null value
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string CreatedDate { get; set; }

        public string UpdatedDate { get; set;}

        [Required]
        [BsonElement(elementName:"Name")]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Contact {  get; set; }

        public double Salary {  get; set; }
    }

    // now creating the response body for this

    public class InsertRecordResponse { 
        public bool IsSuccess {  get; set; }
        // the message contains why of issucces like if succes than why if fail than why fail ?
        public string Message {  get; set; } 
    
    }
}

// inside data access layer folder as class
code inside CrudOperationsDL.cs :



11) we have succesfull inserted data using web api 
current code inside : git repo 


12) all apis done in swagger now testing in postman

{Testing using Postman}

part 6 : 

13) downloand and install postman
14) find url of apis using swagger or launchsettings.json inside properties folder
15) url link : https://localhost:44367/
	       https://localhost:

"iisExpress": {
  "applicationUrl": "http://localhost:15599",
  "sslPort": 44367
}


16) postman testing done only for insert records jumping to completing the app 

17) just incase : 
mongo url : mongodb://localhost:27017/

18) Completed

