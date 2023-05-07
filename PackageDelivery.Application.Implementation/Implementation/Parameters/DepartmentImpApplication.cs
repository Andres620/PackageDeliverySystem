using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Implementation.Implementation.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
	public class DepartmentImpApplication : IDepartmentApplication
	{
		IDepartmentRepository _repository = new DepartmentImpRepository();
		public DepartmentDTO createRecord(DepartmentDTO record)
		{
			DepartmentApplicationMapper mapper = new DepartmentApplicationMapper();
			DepartmentDbModel dbModel = mapper.DTOToDbModelMapper(record);
			DepartmentDbModel response = this._repository.createRecord(dbModel);
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

		public DepartmentDTO getRecordById(int id)
		{
			DepartmentApplicationMapper mapper = new DepartmentApplicationMapper();
			DepartmentDbModel dbModel = _repository.getRecordById(id);
			if (dbModel == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(dbModel);
		}

		public IEnumerable<DepartmentDTO> getRecordsList(string filter)
		{
			DepartmentApplicationMapper mapper = new DepartmentApplicationMapper();
			IEnumerable<DepartmentDbModel> dbModelList = _repository.getRecordsList(filter);
			return mapper.DbModelToDTOMapper(dbModelList);
		}

		public DepartmentDTO updateRecord(DepartmentDTO record)
		{
			DepartmentApplicationMapper mapper = new DepartmentApplicationMapper();
			DepartmentDbModel dbModel = mapper.DTOToDbModelMapper(record);
			DepartmentDbModel response = this._repository.updateRecord(dbModel);
			if (response == null)
			{
				return null;
			}
			return mapper.DbModelToDTOMapper(response);
		}
	}
}
