using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class AddressGUIMapper : ModelMapperBase<AddressModel, AddressDTO>
    {
        public override AddressModel DTOToModelMapper(AddressDTO input)
        {
            return new AddressModel()
            {
                Id = input.Id,
                actual = input.actual,
                IdPerson = (int)input.IdPerson,
                IdTown = (int)input.IdTown,
                immovableType = input.immovableType,
                neighborhood = input.neighborhood,
                number = input.number,
                observations = input.observations,
                streetType = input.streetType
            };
        }

        public override IEnumerable<AddressModel> DTOToModelMapper(IEnumerable<AddressDTO> input)
        {
            IList<AddressModel> list = new List<AddressModel>();
            foreach (var dto in input)
            {
                list.Add(this.DTOToModelMapper(dto));
            }
            return list;
        }

        public override AddressDTO ModelToDTOMapper(AddressModel input)
        {
            return new AddressDTO() 
            { 
                Id = input.Id,
                actual = input.actual,
                IdPerson = input.IdPerson,
                IdTown = input.IdTown,
                immovableType = input.immovableType,
                neighborhood = input.neighborhood,
                number = input.number, 
                observations = input.observations,
                streetType = input.streetType
            };
        }

        public override IEnumerable<AddressDTO> ModelToDTOMapper(IEnumerable<AddressModel> input)
        {
            IList<AddressDTO> list = new List<AddressDTO>();
            foreach (var dto in input)
            {
                list.Add(this.ModelToDTOMapper(dto));
            }
            return list;
        }
    }
}