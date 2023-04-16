using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Core
{
    public class ShipmentStateGUIMapper : ModelMapperBase<ShipmentStateModel, ShipmentStateDTO>
    {
        public override ShipmentStateModel DTOToModelMapper(ShipmentStateDTO input)
        {
            return new ShipmentStateModel()
            {
                Id = input.Id,
                name = input.name
            };
        }

        public override IEnumerable<ShipmentStateModel> DTOToModelMapper(IEnumerable<ShipmentStateDTO> input)
        {
            IList<ShipmentStateModel> list = new List<ShipmentStateModel>();
            foreach (var dto in input)
            {
                list.Add(this.DTOToModelMapper(dto));
            }
            return list;
        }

        public override ShipmentStateDTO ModelToDTOMapper(ShipmentStateModel input)
        {
            return new ShipmentStateDTO()
            {
                Id = input.Id,
                name = input.name
            };
        }

        public override IEnumerable<ShipmentStateDTO> ModelToDTOMapper(IEnumerable<ShipmentStateModel> input)
        {
            IList<ShipmentStateDTO> list = new List<ShipmentStateDTO>();
            foreach (var model in input)
            {
                list.Add(this.ModelToDTOMapper(model));
            }
            return list;
        }
    }
}