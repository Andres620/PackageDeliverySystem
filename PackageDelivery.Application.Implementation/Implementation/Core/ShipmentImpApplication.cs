﻿using PackageDelivery.Application.Contracts.DTO.CoreDTO;
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
	public class ShipmentImpApplication : IShipmentApplication
	{
		IShipmentRepository _repository = new ShipmentImpRepository();
		public ShipmentDTO createRecord(ShipmentDTO record)
		{
			ShipmentApplicationMapper mapper = new ShipmentApplicationMapper();
			ShipmentDbModel dbModel = mapper.DTOToDbModelMapper(record);
			ShipmentDbModel response = this._repository.createRecord(dbModel);
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

		public ShipmentDTO getRecordById(int id)
		{
			ShipmentApplicationMapper mapper = new ShipmentApplicationMapper();
			ShipmentDbModel dbModel = _repository.getRecordById(id);
			if (dbModel == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(dbModel);
		}

		public IEnumerable<ShipmentDTO> getRecordsList(long filter)
		{
			ShipmentApplicationMapper mapper = new ShipmentApplicationMapper();
			IEnumerable<ShipmentDbModel> dbModelList = _repository.getRecordsList(filter);
			return mapper.DbModelToDTOMapper(dbModelList);
		}

		public ShipmentDTO updateRecord(ShipmentDTO record)
		{
			ShipmentApplicationMapper mapper = new ShipmentApplicationMapper();
			ShipmentDbModel dbModel = mapper.DTOToDbModelMapper(record);
			ShipmentDbModel response = this._repository.updateRecord(dbModel);
			if (response == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(response);
		}
	}
}
