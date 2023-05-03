using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.Parameters;
using System;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class PersonImpApplication : IPersonApplication
    {
		//IPersonRepository _repository = new PersonImpRepository();
		public PersonDTO createRecord(PersonDTO record)
        {
            throw new NotImplementedException();
        }

        public bool deleteRecordById(int id)
        {
			throw new NotImplementedException();
			//return _repository.deleteRecordById(id);
		}

        public PersonDTO getRecordById(int id)
        {
			throw new NotImplementedException();
			//PersonApplicationMapper mapper = new PersonApplicationMapper();
			//PersonDbModel dbModel = _repository.getRecordById(id);
			//if (dbModel == null)
			//{
			//	return null;
			//}
			//return mapper.DbModelToDTOMapper(dbModel);
		}

        public IEnumerable<PersonDTO> getRecordsList(string filter)
        {
			throw new NotImplementedException();
			//PersonApplicationMapper mapper = new PersonApplicationMapper();
			//IEnumerable<PersonDbModel> dbModelList = _repository.getRecordsList(filter);
			//return mapper.DbModelToDTOMapper(dbModelList);
		}

        public PersonDTO updateRecord(PersonDTO record)
        {
            throw new NotImplementedException();
        }
    }
}
