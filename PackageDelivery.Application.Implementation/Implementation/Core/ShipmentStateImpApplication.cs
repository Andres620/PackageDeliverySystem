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
	public class ShipmentStateImpApplication : IShipmentStateApplication
	{
		IShipmentStateRepository _repository = new ShipmentStateImpRepository();
		public ShipmentStateDTO createRecord(ShipmentStateDTO record)
		{
			ShipmentStateApplicationMapper mapper = new ShipmentStateApplicationMapper();
			ShipmentStateDbModel dbModel = mapper.DTOToDbModelMapper(record);
			ShipmentStateDbModel response = this._repository.createRecord(dbModel);
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

		public ShipmentStateDTO getRecordById(int id)
		{
			ShipmentStateApplicationMapper mapper = new ShipmentStateApplicationMapper();
			ShipmentStateDbModel dbModel = _repository.getRecordById(id);
			if (dbModel == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(dbModel);
		}

		public IEnumerable<ShipmentStateDTO> getRecordsList(string filter)
		{
			ShipmentStateApplicationMapper mapper = new ShipmentStateApplicationMapper();
			IEnumerable<ShipmentStateDbModel> dbModelList = _repository.getRecordsList(filter);
			return mapper.DbModelToDTOMapper(dbModelList);
		}

		public ShipmentStateDTO updateRecord(ShipmentStateDTO record)
		{
			ShipmentStateApplicationMapper mapper = new ShipmentStateApplicationMapper();
			ShipmentStateDbModel dbModel = mapper.DTOToDbModelMapper(record);
			ShipmentStateDbModel response = this._repository.updateRecord(dbModel);
			if (response == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(response);
		}
	}
}
