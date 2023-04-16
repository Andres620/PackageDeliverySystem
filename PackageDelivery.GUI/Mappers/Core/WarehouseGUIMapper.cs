using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Core
{
    public class WarehouseGUIMapper : ModelMapperBase<WarehouseModel, WarehouseDTO>
    {
        public override WarehouseModel DTOToModelMapper(WarehouseDTO input)
        {
            return new WarehouseModel()
            {
                Id = input.Id,
                name = input.name,
                code = input.code,
                address = input.address,
                latitude = input.latitude,
                longitude = input.longitude,
                idTown = input.idTown
            };
        }

        public override IEnumerable<WarehouseModel> DTOToModelMapper(IEnumerable<WarehouseDTO> input)
        {
            IList<WarehouseModel> list = new List<WarehouseModel>();
            foreach (var dto in input)
            {
                list.Add(this.DTOToModelMapper(dto));
            }
            return list;
        }

        public override WarehouseDTO ModelToDTOMapper(WarehouseModel input)
        {
            return new WarehouseDTO()
            {
                Id = input.Id,
                name = input.name,
                code = input.code,
                address = input.address,
                latitude = input.latitude,
                longitude = input.longitude,
                idTown = input.idTown
            };
        }

        public override IEnumerable<WarehouseDTO> ModelToDTOMapper(IEnumerable<WarehouseModel> input)
        {
            IList<WarehouseDTO> list = new List<WarehouseDTO>();
            foreach (var model in input)
            {
                list.Add(this.ModelToDTOMapper(model));
            }
            return list;
        }
    }
}