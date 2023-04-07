using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class DepartmentGUIMapper : ModelMapperBase<DepartmentModel, DepartmentDTO>
    {
        public override DepartmentModel DTOToModelMapper(DepartmentDTO input)
        {
            return new DepartmentModel()
            {
                Id = input.Id,
                name = input.name

            };
        }

        public override IEnumerable<DepartmentModel> DTOToModelMapper(IEnumerable<DepartmentDTO> input)
        {
            IList<DepartmentModel> list = new List<DepartmentModel>();
            foreach (var dto in input)
            {
                list.Add(this.DTOToModelMapper(dto));
            }
            return list;
        }

        public override DepartmentDTO ModelToDTOMapper(DepartmentModel input)
        {
            return new DepartmentDTO() 
            {
                Id = input.Id,
                name = input.name
            };
        }

        public override IEnumerable<DepartmentDTO> ModelToDTOMapper(IEnumerable<DepartmentModel> input)
        {
            IList<DepartmentDTO> list = new List<DepartmentDTO>();
            foreach (var model in input)
            {
                list.Add(this.ModelToDTOMapper(model));
            }
            return list;
        }
    }
}