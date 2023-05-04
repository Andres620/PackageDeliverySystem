using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    internal class AddressApplicationMapper : DTOMapperBase<AddressDTO, AddressDbModel>
    {
        public override AddressDTO DbModelToDTOMapper(AddressDbModel input)
        {
            return new AddressDTO()
            {
                Id = input.Id,
                streetType = input.streetType,
                number = input.number,
                immovableType = input.immovableType,
                neighborhood = input.neighborhood,
                observations = input.observations,
                actual = input.actual,
                IdPerson = input.IdPerson,
                IdTown = input.IdTown
            };
        }

        public override IEnumerable<AddressDTO> DbModelToDTOMapper(IEnumerable<AddressDbModel> input)
        {
            IList<AddressDTO> list = new List<AddressDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override AddressDbModel DTOToDbModelMapper(AddressDTO input)
        {
            return new AddressDbModel()
            {
                Id = input.Id,
                streetType = input.streetType,
                number = input.number,
                immovableType = input.immovableType,
                neighborhood = input.neighborhood,
                observations = input.observations,
                actual = input.actual,
                IdPerson = input.IdPerson,
                IdTown = input.IdTown
            };
        }

        public override IEnumerable<AddressDbModel> DTOToDbModelMapper(IEnumerable<AddressDTO> input)
        {
            IList<AddressDbModel> list = new List<AddressDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}