using Crud_app_with_mongo.Data_access_layer;
using Crud_app_with_mongo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_app_with_mongo.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class crudoperationsController : ControllerBase
    {
        private readonly ICrudOperationsDL _crudOperationsDL;

        public crudoperationsController(ICrudOperationsDL crudOperationsDL) {
            _crudOperationsDL = crudOperationsDL;
        }

        [HttpPost]
        public async Task<IActionResult> InsertRecord(InsertRecordRequest request)
        {

            InsertRecordResponse response = new InsertRecordResponse();
            try {
                response = await _crudOperationsDL.InsertRecord(request);     
            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs"+ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecord()
        {
            GetAllRecordRepsonse response = new GetAllRecordRepsonse();
            try
            {
                response = await _crudOperationsDL.GetAllRecord();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs" + ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetRecordByID([FromQuery]string ID)
        {
            GetRecordByIDResponse response = new GetRecordByIDResponse();
            try
            {
                response = await _crudOperationsDL.GetRecordByID(ID);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs get id : " + ex.Message;
            }
            return Ok(response);
        }

        // get by name api
        [HttpGet]
        public async Task<IActionResult> GetRecordByName([FromQuery] string Name)
        {
            GetRecordByNameResponse response = new GetRecordByNameResponse();
            try
            {
                response = await _crudOperationsDL.GetRecordByName(Name);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs by Name : " + ex.Message;
            }
            return Ok(response);
        }

        // update records using id
        [HttpPut]
        public async Task<IActionResult> UpdateRecordById(InsertRecordRequest request)
        {
            UpdateRecordbyIdResponse response = new UpdateRecordbyIdResponse();
            try
            {
                response = await _crudOperationsDL.UpdateRecordById(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs for put id : " + ex.Message;
            }
            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateSalaryById(UpdateSalaryByIdRequest request)
        {
            UpdateSalaryByIdResponse response = new UpdateSalaryByIdResponse();
            try
            {
                response = await _crudOperationsDL.UpdateSalaryById(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Messages = "Exception Occurs for put id : " + ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRecordById(DeleteRecordByIdRequest request)
        {
            DeleteRecordByIdResponse response = new DeleteRecordByIdResponse();
            try
            {
                response = await _crudOperationsDL.DeleteRecordById(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs for put id : " + ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllRecord()
        {
            DeleteAllRecordResponse response = new DeleteAllRecordResponse();
            try
            {
                response = await _crudOperationsDL.DeleteAllRecord();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs for deleting all records : " + ex.Message;
            }
            return Ok(response);
        }

    }
}
