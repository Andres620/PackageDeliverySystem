using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
	public class WarehouseImpApplication : IWarehouseApplication
	{
		public WarehouseDTO createRecord(WarehouseDTO record)
		{
			throw new NotImplementedException();
		}

		public bool deleteRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public WarehouseDTO getRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<WarehouseDTO> getRecordsList(string filter)
		{
			throw new NotImplementedException();
		}

		public WarehouseDTO updateRecord(WarehouseDTO record)
		{
			throw new NotImplementedException();
		}
	}
}
