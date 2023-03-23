using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class PersonRepositoryMapper : DbModelMapperBase<PersonDbModel, persona>
    {
        public override PersonDbModel DatabaseToDbModelMapper(persona input)
        {
            return new PersonDbModel()
            {
                Id = input.id,
                firstName = input.primerNombre,
                otherNames = input.otrosNombres,
                firstLastName = input.primerApellido,
                secondLastName = input.segundoApellido,
                cellphone = input.telefono,
                email = input.correo,
                identificationNumber = input.documento,
                IdAddress = (int)input.idDireccion,
                IdDocumentType = input.idTipoDocumento
            };
        }

        public override IEnumerable<PersonDbModel> DatabaseToDbModelMapper(IEnumerable<persona> input)
        {
            IList<PersonDbModel> list = new List<PersonDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override persona DbModelToDatabaseMapper(PersonDbModel input)
        {
            return new persona()
            {
                id = input.Id,
                primerNombre = input.firstName,
                otrosNombres = input.otherNames,
                primerApellido = input.firstLastName,
                segundoApellido = input.secondLastName,
                telefono = input.cellphone,
                correo = input.email,
                documento = input.identificationNumber,
                idDireccion = input.IdAddress,
                idTipoDocumento = input.IdDocumentType
            };
        }

        public override IEnumerable<persona> DbModelToDatabaseMapper(IEnumerable<PersonDbModel> input)
        {
            IList<persona> list = new List<persona>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
