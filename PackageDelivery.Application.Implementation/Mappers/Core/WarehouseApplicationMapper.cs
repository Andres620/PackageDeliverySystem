using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Core
{
    internal class WarehouseApplicationMapper : DTOMapperBase<WarehouseDTO, WarehouseDbModel>
    {
        public override WarehouseDTO DbModelToDTOMapper(WarehouseDbModel input)
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

        public override IEnumerable<WarehouseDTO> DbModelToDTOMapper(IEnumerable<WarehouseDbModel> input)
        {
            IList<WarehouseDTO> list = new List<WarehouseDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override WarehouseDbModel DTOToDbModelMapper(WarehouseDTO input)
        {
            return new WarehouseDbModel()
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

        public override IEnumerable<WarehouseDbModel> DTOToDbModelMapper(IEnumerable<WarehouseDTO> input)
        {
            IList<WarehouseDbModel> list = new List<WarehouseDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}