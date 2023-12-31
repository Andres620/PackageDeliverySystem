﻿using PackageDelivery.Repository.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IDocumentTypeRepository
    {
        DocumentTypeDbModel getRecordById(int id);
        IEnumerable<DocumentTypeDbModel> getRecordsList();
        DocumentTypeDbModel createRecord(DocumentTypeDbModel record);
        DocumentTypeDbModel updateRecord(DocumentTypeDbModel record);
        bool deleteRecordById(int id);
    }
}
