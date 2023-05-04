using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Core
{
    internal class OfficeApplicationMapper : DTOMapperBase<OfficeDTO, OfficeDbModel>
    {
        public override OfficeDTO DbModelToDTOMapper(OfficeDbModel input)
        {
            return new OfficeDTO()
            {
                Id = input.Id,
                name = input.name,
                code = input.code,
                cellphone = input.cellphone,
                address = input.address,
                latitude = input.latitude,
                longitude = input.longitude,
                idTown = input.idTown
            };
        }

        public override IEnumerable<OfficeDTO> DbModelToDTOMapper(IEnumerable<OfficeDbModel> input)
        {
            IList<OfficeDTO> list = new List<OfficeDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override OfficeDbModel DTOToDbModelMapper(OfficeDTO input)
        {
            return new OfficeDbModel()
            {
                Id = input.Id,
                name = input.name,
                code = input.code,
                cellphone = input.cellphone,
                address = input.address,
                latitude = input.latitude,
                longitude = input.longitude,
                idTown = input.idTown
            };
        }

        public override IEnumerable<OfficeDbModel> DTOToDbModelMapper(IEnumerable<OfficeDTO> input)
        {
            IList<OfficeDbModel> list = new List<OfficeDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}