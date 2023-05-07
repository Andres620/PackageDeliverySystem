using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Implementation.Mappers.Core;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Core;
using PackageDelivery.Repository.Implementation.Implementation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
	public class HistoryImpApplication : IHistoryApplication
	{
		IHistoryRepository _repository = new HistoryImpRepository();
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

		public IEnumerable<HistoryDTO> getRecordsList(string filter)
		{
			HistoryApplicationMapper mapper = new HistoryApplicationMapper();
			IEnumerable<HistoryDbModel> dbModelList = _repository.getRecordsList(filter);
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
