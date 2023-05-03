using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
	public class AddressImpApplication : IAddressApplication
	{
		public AddressDTO createRecord(AddressDTO record)
		{
			throw new NotImplementedException();
		}

		public bool deleteRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public AddressDTO getRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<AddressDTO> getRecordsList(string filter)
		{
			throw new NotImplementedException();
		}

		public AddressDTO updateRecord(AddressDTO record)
		{
			throw new NotImplementedException();
		}
	}
}
