﻿using Crud_app_with_mongo.Model;

namespace Crud_app_with_mongo.Data_access_layer
{
    public interface ICrudOperationsDL
    {
        public Task<InsertRecordResponse> InsertRecord(InsertRecordRequest request);
    }
}
