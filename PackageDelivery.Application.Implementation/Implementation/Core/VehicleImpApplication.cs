﻿using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Implementation.Mappers.Core;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
    public class VehicleImpApplication : IVehicleApplication
	{
		IVehicleRepository _repository;

        public VehicleImpApplication(IVehicleRepository _repository)
        {
            this._repository = _repository;
        }
        public VehicleDTO createRecord(VehicleDTO record)
		{
			VehicleApplicationMapper mapper = new VehicleApplicationMapper();
			VehicleDbModel dbModel = mapper.DTOToDbModelMapper(record);
			VehicleDbModel response = this._repository.createRecord(dbModel);
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

		public VehicleDTO getRecordById(int id)
		{
			VehicleApplicationMapper mapper = new VehicleApplicationMapper();
			VehicleDbModel dbModel = _repository.getRecordById(id);
			if (dbModel == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(dbModel);
		}

		public IEnumerable<VehicleDTO> getRecordsList()
		{
			VehicleApplicationMapper mapper = new VehicleApplicationMapper();
			IEnumerable<VehicleDbModel> dbModelList = _repository.getRecordsList();
			return mapper.DbModelToDTOMapper(dbModelList);
		}

		public VehicleDTO updateRecord(VehicleDTO record)
		{
			VehicleApplicationMapper mapper = new VehicleApplicationMapper();
			VehicleDbModel dbModel = mapper.DTOToDbModelMapper(record);
			VehicleDbModel response = this._repository.updateRecord(dbModel);
			if (response == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(response);
		}
	}
}
