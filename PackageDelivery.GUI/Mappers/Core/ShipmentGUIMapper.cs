using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Core
{
    public class ShipmentGUIMapper : ModelMapperBase<ShipmentModel, ShipmentDTO>
    {
        public override ShipmentModel DTOToModelMapper(ShipmentDTO input)
        {
            return new ShipmentModel()
            {
                Id = input.Id,
                shippingDate = input.shippingDate,
                price = input.price,
                idSender = input.idSender,
                idDestinationAddress = input.idDestinationAddress,
                idPackage = input.idPackage,
                idShipmentState = input.idShipmentState,
                idTransportType = input.idTransportType
            };
        }

        public override IEnumerable<ShipmentModel> DTOToModelMapper(IEnumerable<ShipmentDTO> input)
        {
            IList<ShipmentModel> list = new List<ShipmentModel>(); 
            foreach (var dto in input) 
            {
                list.Add(this.DTOToModelMapper(dto));
            }
            return list;
        }

        public override ShipmentDTO ModelToDTOMapper(ShipmentModel input)
        {
            return new ShipmentDTO()
            {
                Id = input.Id,
                shippingDate = input.shippingDate,
                price = input.price,
                idSender = input.idSender,
                idDestinationAddress = input.idDestinationAddress,
                idPackage = input.idPackage,
                idShipmentState = input.idShipmentState,
                idTransportType = input.idTransportType
            };
        }

        public override IEnumerable<ShipmentDTO> ModelToDTOMapper(IEnumerable<ShipmentModel> input)
        {
            IList<ShipmentDTO> list = new List<ShipmentDTO>();
            foreach (var model in input)
            {
                list.Add(this.ModelToDTOMapper(model));
            }
            return list;
        }
    }
}