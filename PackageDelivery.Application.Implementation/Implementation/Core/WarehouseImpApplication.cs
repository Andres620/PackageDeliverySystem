using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Implementation.Mappers.Core;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Implementation.Implementation.Core;
using PackageDelivery.Repository.Implementation.Implementation.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
	public class WarehouseImpApplication : IWarehouseApplication
	{
		IWarehouseRepository _repository = new WarehouseImpRepository();
		public WarehouseDTO createRecord(WarehouseDTO record)
		{
			WarehouseApplicationMapper mapper = new WarehouseApplicationMapper();
			WarehouseDbModel dbModel = mapper.DTOToDbModelMapper(record);
			WarehouseDbModel response = this._repository.createRecord(dbModel);
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

		public WarehouseDTO getRecordById(int id)
		{
			WarehouseApplicationMapper mapper = new WarehouseApplicationMapper();
			WarehouseDbModel dbModel = _repository.getRecordById(id);
			if (dbModel == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(dbModel);
		}

		public IEnumerable<WarehouseDTO> getRecordsList(string filter)
		{
			WarehouseApplicationMapper mapper = new WarehouseApplicationMapper();
			IEnumerable<WarehouseDbModel> dbModelList = _repository.getRecordsList(filter);
			return mapper.DbModelToDTOMapper(dbModelList);
		}

		public WarehouseDTO updateRecord(WarehouseDTO record)
		{
			WarehouseApplicationMapper mapper = new WarehouseApplicationMapper();
			WarehouseDbModel dbModel = mapper.DTOToDbModelMapper(record);
			WarehouseDbModel response = this._repository.updateRecord(dbModel);
			if (response == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(response);
		}
	}
}
