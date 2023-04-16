using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Core
{
    public class PackageGUIMapper : ModelMapperBase<PackageModel, PackageDTO>
    {
        public override PackageModel DTOToModelMapper(PackageDTO input)
        {
            return new PackageModel()
            {
                Id = input.Id,
                weight = input.weight,
                height = input.height,
                depth = input.depth,
                width = input.width,
                idOffice = input.idOffice
            };
        }

        public override IEnumerable<PackageModel> DTOToModelMapper(IEnumerable<PackageDTO> input)
        {
            IList<PackageModel> list = new List<PackageModel>();
            foreach (var dto in input)
            {
                list.Add(this.DTOToModelMapper(dto));
            }
            return list;
        }

        public override PackageDTO ModelToDTOMapper(PackageModel input)
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

        public override IEnumerable<PackageDTO> ModelToDTOMapper(IEnumerable<PackageModel> input)
        {
            IList<PackageDTO> list = new List<PackageDTO>();
            foreach (var model in input)
            {
                list.Add(this.ModelToDTOMapper(model));
            }
            return list;
        }
    }
}