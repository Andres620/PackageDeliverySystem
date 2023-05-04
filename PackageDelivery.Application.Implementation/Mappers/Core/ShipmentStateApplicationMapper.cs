using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Core
{
    internal class ShipmentStateApplicationMapper : DTOMapperBase<ShipmentStateDTO, ShipmentStateDbModel>
    {
        public override ShipmentStateDTO DbModelToDTOMapper(ShipmentStateDbModel input)
        {
            return new ShipmentStateDTO()
            {
                Id = input.Id,
                name = input.name
            };
        }

        public override IEnumerable<ShipmentStateDTO> DbModelToDTOMapper(IEnumerable<ShipmentStateDbModel> input)
        {
            IList<ShipmentStateDTO> list = new List<ShipmentStateDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override ShipmentStateDbModel DTOToDbModelMapper(ShipmentStateDTO input)
        {
            return new ShipmentStateDbModel()
            {
                Id = input.Id,
                name = input.name
            };
        }

        public override IEnumerable<ShipmentStateDbModel> DTOToDbModelMapper(IEnumerable<ShipmentStateDTO> input)
        {
            IList<ShipmentStateDbModel> list = new List<ShipmentStateDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}