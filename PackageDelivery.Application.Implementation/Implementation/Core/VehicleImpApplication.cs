using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
	public class VehicleImpApplication : IVehicleApplication
	{
		public VehicleDTO createRecord(VehicleDTO record)
		{
			throw new NotImplementedException();
		}

		public bool deleteRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public VehicleDTO getRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<VehicleDTO> getRecordsList(string filter)
		{
			throw new NotImplementedException();
		}

		public VehicleDTO updateRecord(VehicleDTO record)
		{
			throw new NotImplementedException();
		}
	}
}
