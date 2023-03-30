using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Implementation.Mappers.Parameters
{
    public class PersonGUIMapper : ModelMapperBase<PersonModel, PersonDTO>
    {
        public override PersonModel DTOToModelMapper(PersonDTO input)
        {
            return new PersonModel()
            {
                Id = input.Id,
                firstName = input.firstName,
                otherNames = input.otherNames,
                firstLastname = input.firstLastName,
                secondLastname = input.secondLastName,
                cellphone = input.cellphone,
                email = input.email,
                identificationNumber = input.identificationNumber,
                idDocumentType = input.IdDocumentType
            };
        }

        public override IEnumerable<PersonModel> DTOToModelMapper(IEnumerable<PersonDTO> input)
        {
            IList<PersonModel> list = new List<PersonModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override PersonDTO ModelToDTOMapper(PersonModel input)
        {
            return new PersonDTO()
            {
                Id = input.Id,
                firstName = input.firstName,
                otherNames = input.otherNames,
                firstLastName = input.firstLastname,
                secondLastName = input.secondLastname,
                cellphone = input.cellphone,
                email = input.email,
                identificationNumber = input.identificationNumber,
                IdDocumentType = input.idDocumentType
            };
        }

        public override IEnumerable<PersonDTO> ModelToDTOMapper(IEnumerable<PersonModel> input)
        {
            IList<PersonDTO> list = new List<PersonDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}