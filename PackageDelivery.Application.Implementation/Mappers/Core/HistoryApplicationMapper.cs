using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository_Contracts.DbModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Mappers.Core
{
	internal class HistoryApplicationMapper : DTOMapperBase<HistoryDTO, HistoryDbModel>
	{
		public override HistoryDTO DbModelToDTOMapper(HistoryDbModel input)
		{
			return new HistoryDTO() { 
				Id = input.Id,
				entryDate = input.entryDate,
				departureDate = input.departureDate,
				description = input.description,
				idPackage = input.idPackage,	
				idWarehouse = input.idWarehouse
			};
		}

		public override IEnumerable<HistoryDTO> DbModelToDTOMapper(IEnumerable<HistoryDbModel> input)
		{
			IList<HistoryDTO> list = new List<HistoryDTO>();
			foreach (var item in input)
			{
				list.Add(this.DbModelToDTOMapper(item));
			}
			return list;
		}

		public override HistoryDbModel DTOToDbModelMapper(HistoryDTO input)
		{
			return new HistoryDbModel()
			{
				Id = input.Id,
				entryDate = input.entryDate,
				departureDate = input.departureDate,
				description = input.description,
				idPackage = input.idPackage,
				idWarehouse = input.idWarehouse
			};
		}

		public override IEnumerable<HistoryDbModel> DTOToDbModelMapper(IEnumerable<HistoryDTO> input)
		{
			IList<HistoryDbModel> list = new List<HistoryDbModel>();
			foreach (var item in input)
			{
				list.Add(this.DTOToDbModelMapper(item));
			}
			return list;
		}
	}
}
