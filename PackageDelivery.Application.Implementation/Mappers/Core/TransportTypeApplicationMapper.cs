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
	internal class TransportTypeApplicationMapper : DTOMapperBase<TransportTypeDTO, TransportTypeDbModel>
	{
		public override TransportTypeDTO DbModelToDTOMapper(TransportTypeDbModel input)
		{
			return new TransportTypeDTO()
			{
				Id = input.Id,
				name = input.name
			};
		}

		public override IEnumerable<TransportTypeDTO> DbModelToDTOMapper(IEnumerable<TransportTypeDbModel> input)
		{
			IList<TransportTypeDTO> list = new List<TransportTypeDTO>();
			foreach (var item in input)
			{
				list.Add(this.DbModelToDTOMapper(item));
			}
			return list;
		}

		public override TransportTypeDbModel DTOToDbModelMapper(TransportTypeDTO input)
		{
			return new TransportTypeDbModel()
			{
				Id = input.Id,
				name = input.name
			};
		}

		public override IEnumerable<TransportTypeDbModel> DTOToDbModelMapper(IEnumerable<TransportTypeDTO> input)
		{
			IList<TransportTypeDbModel> list = new List<TransportTypeDbModel>();
			foreach (var item in input)
			{
				list.Add(this.DTOToDbModelMapper(item));
			}
			return list;
		}
	}
}
