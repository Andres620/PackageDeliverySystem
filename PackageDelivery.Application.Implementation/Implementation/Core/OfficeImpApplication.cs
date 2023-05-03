using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
	public class OfficeImpApplication : IOfficeApplication
	{
		public OfficeDTO createRecord(OfficeDTO record)
		{
			throw new NotImplementedException();
		}

		public bool deleteRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public OfficeDTO getRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<OfficeDTO> getRecordsList(string filter)
		{
			throw new NotImplementedException();
		}

		public OfficeDTO updateRecord(OfficeDTO record)
		{
			throw new NotImplementedException();
		}
	}
}
