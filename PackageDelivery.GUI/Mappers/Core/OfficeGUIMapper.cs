using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Core
{
    public class OfficeGUIMapper : ModelMapperBase<OfficeModel, OfficeDTO>
    {
        public override OfficeModel DTOToModelMapper(OfficeDTO input)
        {
            return new OfficeModel()
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

        public override IEnumerable<OfficeModel> DTOToModelMapper(IEnumerable<OfficeDTO> input)
        {
            IList<OfficeModel> list = new List<OfficeModel>();
            foreach (var dto in input)
            {
                list.Add(this.DTOToModelMapper(dto));
            }
            return list;
        }

        public override OfficeDTO ModelToDTOMapper(OfficeModel input)
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

        public override IEnumerable<OfficeDTO> ModelToDTOMapper(IEnumerable<OfficeModel> input)
        {
            IList<OfficeDTO> list = new List<OfficeDTO>();
            foreach (var model in input)
            {
                list.Add(this.ModelToDTOMapper(model));
            }
            return list;
        }
    }
}