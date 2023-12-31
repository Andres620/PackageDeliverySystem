﻿using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Implementation.Mappers.Core;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
    public class OfficeImpApplication : IOfficeApplication
	{
		IOfficeRepository _repository;

        public OfficeImpApplication(IOfficeRepository repository)
        {
            this._repository = repository;
        }

        public OfficeDTO createRecord(OfficeDTO record)
		{
			OfficeApplicationMapper mapper = new OfficeApplicationMapper();
			OfficeDbModel dbModel = mapper.DTOToDbModelMapper(record);
			OfficeDbModel response = this._repository.createRecord(dbModel);
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

		public OfficeDTO getRecordById(int id)
		{
			OfficeApplicationMapper mapper = new OfficeApplicationMapper();
			OfficeDbModel dbModel = _repository.getRecordById(id);
			if (dbModel == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(dbModel);
		}

		public IEnumerable<OfficeDTO> getRecordsList()
		{
			OfficeApplicationMapper mapper = new OfficeApplicationMapper();
			IEnumerable<OfficeDbModel> dbModelList = _repository.getRecordsList();
			return mapper.DbModelToDTOMapper(dbModelList);
		}

		public OfficeDTO updateRecord(OfficeDTO record)
		{
			OfficeApplicationMapper mapper = new OfficeApplicationMapper();
			OfficeDbModel dbModel = mapper.DTOToDbModelMapper(record);
			OfficeDbModel response = this._repository.updateRecord(dbModel);
			if (response == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(response);
		}
	}
}
