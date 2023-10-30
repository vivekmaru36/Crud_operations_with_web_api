﻿using Crud_app_with_mongo.Data_access_layer;
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
    }
}
