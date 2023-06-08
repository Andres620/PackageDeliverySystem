using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class DocumentTypeImpApplication : IDocumentTypeApplication
    {
        IDocumentTypeRepository _repository;

        public DocumentTypeImpApplication(IDocumentTypeRepository repository)
        {
            this._repository = repository;
        }
        public DocumentTypeDTO createRecord(DocumentTypeDTO record)
        {
			DocumentTypeApplicationMapper mapper = new DocumentTypeApplicationMapper();
			DocumentTypeDbModel dbModel = mapper.DTOToDbModelMapper(record);
			DocumentTypeDbModel response = this._repository.createRecord(dbModel);
			if (response == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(response);
		}

        public bool deleteRecordById(int id)
        {
            return _repository.deleteRecordById(id);
        }

        public DocumentTypeDTO getRecordById(int id)
        {
            DocumentTypeApplicationMapper mapper = new DocumentTypeApplicationMapper();
            DocumentTypeDbModel dbModel = _repository.getRecordById(id);
            if(dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<DocumentTypeDTO> getRecordsList()
        {
            DocumentTypeApplicationMapper mapper = new DocumentTypeApplicationMapper();
            IEnumerable<DocumentTypeDbModel> dbModelList = _repository.getRecordsList();
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public DocumentTypeDTO updateRecord(DocumentTypeDTO record)
        {
			DocumentTypeApplicationMapper mapper = new DocumentTypeApplicationMapper();
			DocumentTypeDbModel dbModel = mapper.DTOToDbModelMapper(record);
			DocumentTypeDbModel response = this._repository.updateRecord(dbModel);
			if (response == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(response);
		}
    }
}
