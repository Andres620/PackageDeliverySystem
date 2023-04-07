using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Core
{
    public class VehicleGUIMapper : ModelMapperBase<VehicleModel, VehicleDTO>
    {
        public override VehicleModel DTOToModelMapper(VehicleDTO input)
        {
            return new VehicleModel()
            {
                Id = input.Id,
                plate = input.plate,
                idTransportType = input.idTransportType
            };
        }

        public override IEnumerable<VehicleModel> DTOToModelMapper(IEnumerable<VehicleDTO> input)
        {
            IList<VehicleModel> list = new List<VehicleModel>();
            foreach (var dto in input)
            {
                list.Add(this.DTOToModelMapper(dto));
            }
            return list;
        }

        public override VehicleDTO ModelToDTOMapper(VehicleModel input)
        {
            return new VehicleDTO()
            {
                Id = input.Id,
                plate = input.plate,
                idTransportType = input.idTransportType
            };
        }

        public override IEnumerable<VehicleDTO> ModelToDTOMapper(IEnumerable<VehicleModel> input)
        {
            IList<VehicleDTO> list = new List<VehicleDTO>();
            foreach (var model in input) 
            {
                list.Add(this.ModelToDTOMapper(model));
            }
            return list;
        }
    }
}