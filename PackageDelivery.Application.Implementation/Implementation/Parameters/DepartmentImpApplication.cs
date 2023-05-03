using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
	public class DepartmentImpApplication : IDepartmentApplication
	{
		public DepartmentDTO createRecord(DepartmentDTO record)
		{
			throw new NotImplementedException();
		}

		public bool deleteRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public DepartmentDTO getRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<DepartmentDTO> getRecordsList(string filter)
		{
			throw new NotImplementedException();
		}

		public DepartmentDTO updateRecord(DepartmentDTO record)
		{
			throw new NotImplementedException();
		}
	}
}
