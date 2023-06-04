using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Implementation.Mappers.Core;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
    public class HistoryImpApplication : IHistoryApplication
	{
		IHistoryRepository _repository;

        public HistoryImpApplication(IHistoryRepository repository)
        {
            this._repository = repository;
        }

        public HistoryDTO createRecord(HistoryDTO record)
		{
			HistoryApplicationMapper mapper = new HistoryApplicationMapper();
			HistoryDbModel dbModel = mapper.DTOToDbModelMapper(record);
			HistoryDbModel response = this._repository.createRecord(dbModel);
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

		public HistoryDTO getRecordById(int id)
		{
			HistoryApplicationMapper mapper = new HistoryApplicationMapper();
			HistoryDbModel dbModel = _repository.getRecordById(id);
			if (dbModel == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(dbModel);
		}

		public IEnumerable<HistoryDTO> getRecordsList()
		{
			HistoryApplicationMapper mapper = new HistoryApplicationMapper();
			IEnumerable<HistoryDbModel> dbModelList = _repository.getRecordsList();
			return mapper.DbModelToDTOMapper(dbModelList);
		}

		public HistoryDTO updateRecord(HistoryDTO record)
		{
			HistoryApplicationMapper mapper = new HistoryApplicationMapper();
			HistoryDbModel dbModel = mapper.DTOToDbModelMapper(record);
			HistoryDbModel response = this._repository.updateRecord(dbModel);
			if (response == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(response);
		}
	}
}
