using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Implementation.Implementation.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class TownImpApplication : ITownApplication
	{
		ITownRepository _repository = new TownImpRepository();
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

		public IEnumerable<TownDTO> getRecordsList(string filter)
		{
			TownApplicationMapper mapper = new TownApplicationMapper();
			IEnumerable<TownDbModel> dbModelList = _repository.getRecordsList(filter);
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
