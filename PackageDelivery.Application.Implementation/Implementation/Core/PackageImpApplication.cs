﻿using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
	public class PackageImpApplication : IPackageApplication
	{
		public PackageDTO createRecord(PackageDTO record)
		{
			throw new NotImplementedException();
		}

		public bool deleteRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public PackageDTO getRecordById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PackageDTO> getRecordsList(string filter)
		{
			throw new NotImplementedException();
		}

		public PackageDTO updateRecord(PackageDTO record)
		{
			throw new NotImplementedException();
		}
	}
}