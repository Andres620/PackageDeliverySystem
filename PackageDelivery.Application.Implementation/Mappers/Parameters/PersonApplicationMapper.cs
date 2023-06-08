
using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Repository.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class PersonApplicationMapper : DTOMapperBase<PersonDTO, PersonDbModel>
    {
        public override PersonDTO DbModelToDTOMapper(PersonDbModel input)
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
                IdDocumentType = input.IdDocumentType
            };
        }

        public override IEnumerable<PersonDTO> DbModelToDTOMapper(IEnumerable<PersonDbModel> input)
        {
            IList<PersonDTO> list = new List<PersonDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override PersonDbModel DTOToDbModelMapper(PersonDTO input)
        {
            return new PersonDbModel()
            {
                Id = input.Id,
                FirstName = input.firstName,
                OtherNames = input.otherNames,
                FirstLastname = input.firstLastName,
                SecondLastname = input.secondLastName,
                IdentificationNumber = input.identificationNumber,
                Cellphone = input.cellphone,
                Email = input.email,
                Address = input.IdAddress,
                IdDocumentType = input.IdDocumentType
            };
        }

        public override IEnumerable<PersonDbModel> DTOToDbModelMapper(IEnumerable<PersonDTO> input)
        {
            IList<PersonDbModel> list = new List<PersonDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}
