using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
	public class ShipmentStateImpApplication : IShipmentStateApplication
	{
		public ShipmentStateDTO createRecord(ShipmentStateDTO record)
		{
			throw new NotImplementedException();
		}

		public bool deleteRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public ShipmentStateDTO getRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ShipmentStateDTO> getRecordsList(string filter)
		{
			throw new NotImplementedException();
		}

		public ShipmentStateDTO updateRecord(ShipmentStateDTO record)
		{
			throw new NotImplementedException();
		}
	}
}
