using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
	internal class TownApplicationMapper : DTOMapperBase<TownDTO, TownDbModel>
	{
		public override TownDTO DbModelToDTOMapper(TownDbModel input)
		{
			return new TownDTO()
			{
				Id = input.Id,
				name = input.name,
				IdDepartment = input.IdDepartment
			};
		}

		public override IEnumerable<TownDTO> DbModelToDTOMapper(IEnumerable<TownDbModel> input)
		{
			IList<TownDTO> list = new List<TownDTO>();
			foreach (var item in input)
			{
				list.Add(this.DbModelToDTOMapper(item));
			}
			return list;
		}

		public override TownDbModel DTOToDbModelMapper(TownDTO input)
		{
			return new TownDbModel(){
				Id = input.Id,
				name = input.name,
				IdDepartment = input.IdDepartment
			};
		}

		public override IEnumerable<TownDbModel> DTOToDbModelMapper(IEnumerable<TownDTO> input)
		{
			IList<TownDbModel> list = new List<TownDbModel>();
			foreach (var item in input)
			{
				list.Add(this.DTOToDbModelMapper(item));
			}
			return list;
		}
	}
}
