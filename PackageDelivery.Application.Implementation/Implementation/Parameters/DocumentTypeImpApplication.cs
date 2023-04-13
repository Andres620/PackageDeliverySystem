﻿using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.Implementation.Parameters;
using PackageDelivery.Repository_Contracts.Interfaces.Parameters;
using System;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class DocumentTypeImpApplication : IDocumentTypeApplication
    {
        IDocumentTypeRepository _repository = new DocumentTypeImpRepository();
        public DocumentTypeDTO createRecord(DocumentTypeDTO record)
        {
            throw new NotImplementedException();
        }

        public bool deleteRecordById(int id)
        {
            return _repository.deleteRecordById(id);
        }

        public DocumentTypeDTO getRecordById(int id)
        {
            DocumentTypeApplicationMapper mapper = new DocumentTypeApplicationMapper();
            DocumentTypeDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<DocumentTypeDTO> getRecordsList(string filter)
        {
            DocumentTypeApplicationMapper mapper = new DocumentTypeApplicationMapper();
            IEnumerable<DocumentTypeDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public DocumentTypeDTO updateRecord(DocumentTypeDTO record)
        {
            throw new NotImplementedException();
        }
    }
}