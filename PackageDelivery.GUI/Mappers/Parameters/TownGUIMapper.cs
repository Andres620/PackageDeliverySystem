using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class TownGUIMapper : ModelMapperBase<TownModel, TownDTO>
    {
        public override TownModel DTOToModelMapper(TownDTO input)
        {
            return new TownModel() 
            { 
                Id = input.Id,
                name = input.name,
                IdDepartment = input.IdDepartment
            };
        }

        public override IEnumerable<TownModel> DTOToModelMapper(IEnumerable<TownDTO> input)
        {
            IList<TownModel> list = new List<TownModel>();
            foreach (var dto in input)
            {
                list.Add(DTOToModelMapper(dto));
            }
            return list;
        }

        public override TownDTO ModelToDTOMapper(TownModel input)
        {
            return new TownDTO() 
            {
                Id = input.Id,
                name = input.name,
                IdDepartment = input.IdDepartment
            };
        }

        public override IEnumerable<TownDTO> ModelToDTOMapper(IEnumerable<TownModel> input)
        {
            IList<TownDTO> list = new List<TownDTO>();
            foreach (var model in input)
            {
                list.Add(this.ModelToDTOMapper(model));
            }
            return list;
        }
    }
}