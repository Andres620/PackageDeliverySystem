using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
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
                firstName = input.firstName,
                otherNames = input.otherNames,
                firstLastName = input.firstLastName,
                secondLastName = input.secondLastName,
                cellphone = input.cellphone,
                email = input.email,
                identificationNumber = input.identificationNumber,
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
                firstName = input.firstName,
                otherNames = input.otherNames,
                firstLastName = input.firstLastName,
                secondLastName = input.secondLastName,
                cellphone = input.cellphone,
                email = input.email,
                identificationNumber = input.identificationNumber,
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