using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
	public class TownImpApplication : ITownApplication
	{
		public TownDTO createRecord(TownDTO record)
		{
			throw new NotImplementedException();
		}

		public bool deleteRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public TownDTO getRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TownDTO> getRecordsList(string filter)
		{
			throw new NotImplementedException();
		}

		public TownDTO updateRecord(TownDTO record)
		{
			throw new NotImplementedException();
		}
	}
}
