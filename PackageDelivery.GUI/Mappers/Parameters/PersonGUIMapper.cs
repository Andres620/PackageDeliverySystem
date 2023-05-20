
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
                FirstName = input.firstName,
                OtherNames = input.otherNames,
                FirstLastname = input.firstLastName,
                SecondLastname = input.secondLastName,
                IdentificationNumber = input.identificationNumber,
                Cellphone = input.cellphone,
                Email = input.email,
                Address = (int)input.IdAddress,
                IdentificationType = input.IdDocumentType
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
                firstName = input.FirstName,
                otherNames = input.OtherNames,
                firstLastName = input.FirstLastname,
                secondLastName = input.SecondLastname,
                identificationNumber = input.IdentificationNumber,
                cellphone = input.Cellphone,
                email = input.Email,
                IdAddress = input.Address,
                IdDocumentType = input.IdentificationType
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
