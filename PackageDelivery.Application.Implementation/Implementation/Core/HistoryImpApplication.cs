using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
	public class HistoryImpApplication : IHistoryApplication
	{
		public HistoryDTO createRecord(HistoryDTO record)
		{
			throw new NotImplementedException();
		}

		public bool deleteRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public HistoryDTO getRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<HistoryDTO> getRecordsList(string filter)
		{
			throw new NotImplementedException();
		}

		public HistoryDTO updateRecord(HistoryDTO record)
		{
			throw new NotImplementedException();
		}
	}
}
