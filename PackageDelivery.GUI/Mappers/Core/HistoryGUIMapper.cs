using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Core
{
    public class HistoryGUIMapper : ModelMapperBase<HistoryModel, HistoryDTO>
    {
        public override HistoryModel DTOToModelMapper(HistoryDTO input)
        {
            return new HistoryModel()
            {
                Id = input.Id,
                entryDate = input.entryDate,
                departureDate = input.departureDate,
                description = input.description,
                idPackage = input.idPackage,
                idWarehouse = input.idWarehouse,
            };
        }

        public override IEnumerable<HistoryModel> DTOToModelMapper(IEnumerable<HistoryDTO> input)
        {
            IList<HistoryModel> list = new List<HistoryModel>();
            foreach (var dto in input)
            {
                list.Add(this.DTOToModelMapper(dto));
            }
            return list;
        }

        public override HistoryDTO ModelToDTOMapper(HistoryModel input)
        {
            return new HistoryDTO()
            {
                Id = input.Id,
                entryDate = input.entryDate,
                departureDate = input.departureDate,
                description = input.description,
                idPackage = input.idPackage,
                idWarehouse = input.idWarehouse
            };
        }

        public override IEnumerable<HistoryDTO> ModelToDTOMapper(IEnumerable<HistoryModel> input)
        {
            IList<HistoryDTO> list = new List<HistoryDTO>();
            foreach (var model in input)
            {
                list.Add(this.ModelToDTOMapper(model));
            }
            return list;
        }
    }
}