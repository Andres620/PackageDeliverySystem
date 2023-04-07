using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Core
{
    public class TransportTypeGUIMapper : ModelMapperBase<TransportTypeModel, TransportTypeDTO>
    {
        public override TransportTypeModel DTOToModelMapper(TransportTypeDTO input)
        {
            return new TransportTypeModel()
            {
                Id = input.Id,
                name = input.name
            };
        }

        public override IEnumerable<TransportTypeModel> DTOToModelMapper(IEnumerable<TransportTypeDTO> input)
        {
            IList<TransportTypeModel> list = new List<TransportTypeModel>();
            foreach (var dto in input)
            {
                list.Add(this.DTOToModelMapper(dto));
            }
            return list;
        }

        public override TransportTypeDTO ModelToDTOMapper(TransportTypeModel input)
        {
            return new TransportTypeDTO()
            {
                Id = input.Id,
                name = input.name
            };
        }

        public override IEnumerable<TransportTypeDTO> ModelToDTOMapper(IEnumerable<TransportTypeModel> input)
        {
            IList<TransportTypeDTO> list = new List<TransportTypeDTO>();
            foreach (var model in input)
            {
                list.Add(this.ModelToDTOMapper(model));
            }
            return list;
        }
    }
}