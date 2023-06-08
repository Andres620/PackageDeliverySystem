using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class TownImpApplication : ITownApplication
	{
		ITownRepository _repository;

        public TownImpApplication(ITownRepository repository)
        {
			this._repository = repository;
        }
        public TownDTO createRecord(TownDTO record)
		{
			TownApplicationMapper mapper = new TownApplicationMapper();
			TownDbModel dbModel = mapper.DTOToDbModelMapper(record);
			TownDbModel response = this._repository.createRecord(dbModel);
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

		public TownDTO getRecordById(int id)
		{
			TownApplicationMapper mapper = new TownApplicationMapper();
			TownDbModel dbModel = _repository.getRecordById(id);
			if (dbModel == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(dbModel);
		}

		public IEnumerable<TownDTO> getRecordsList()
		{
			TownApplicationMapper mapper = new TownApplicationMapper();
			IEnumerable<TownDbModel> dbModelList = _repository.getRecordsList();
			return mapper.DbModelToDTOMapper(dbModelList);
		}

		public TownDTO updateRecord(TownDTO record)
		{
			TownApplicationMapper mapper = new TownApplicationMapper();
			TownDbModel dbModel = mapper.DTOToDbModelMapper(record);
			TownDbModel response = this._repository.updateRecord(dbModel);
			if (response == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(response);
		}
	}
}
