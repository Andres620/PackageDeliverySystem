using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Core
{
    internal class PackageApplicationMapper : DTOMapperBase<PackageDTO, PackageDbModel>

    {
        public override PackageDTO DbModelToDTOMapper(PackageDbModel input)
        {
            return new PackageDTO()
            {
                Id = input.Id,
                weight = input.weight,
                height = input.height,
                depth = input.depth,
                width = input.width,
                idOffice = input.idOffice
            };
        }

        public override IEnumerable<PackageDTO> DbModelToDTOMapper(IEnumerable<PackageDbModel> input)
        {
            IList<PackageDTO> list = new List<PackageDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override PackageDbModel DTOToDbModelMapper(PackageDTO input)
        {
            return new PackageDbModel()
            {
                Id = input.Id,
                weight = input.weight,
                height = input.height,
                depth = input.depth,
                width = input.width,
                idOffice = input.idOffice
            };
        }

        public override IEnumerable<PackageDbModel> DTOToDbModelMapper(IEnumerable<PackageDTO> input)
        {
            IList<PackageDbModel> list = new List<PackageDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}