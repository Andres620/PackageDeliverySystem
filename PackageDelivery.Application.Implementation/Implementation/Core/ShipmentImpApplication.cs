using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
	public class ShipmentImpApplication : IShipmentApplication
	{
		public ShipmentDTO createRecord(ShipmentDTO record)
		{
			throw new NotImplementedException();
		}

		public bool deleteRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public ShipmentDTO getRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ShipmentDTO> getRecordsList(string filter)
		{
			throw new NotImplementedException();
		}

		public ShipmentDTO updateRecord(ShipmentDTO record)
		{
			throw new NotImplementedException();
		}
	}
}
