
using PackageDelivery.Repository.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
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
                FirstName = input.primerNombre,
                OtherNames = input.otrosNombres,
                FirstLastname = input.primerApellido,
                SecondLastname = input.segundoApellido,
                IdentificationNumber = input.documento,
                Cellphone = input.telefono,
                Email = input.correo,
                Address = input.idDireccion,
                IdentificationType = input.idTipoDocumento
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
                id = (int)input.Id,
                primerNombre = input.FirstName,
                otrosNombres = input.OtherNames,
                primerApellido = input.FirstLastname,
                segundoApellido = input.SecondLastname,
                documento = input.IdentificationNumber,
                telefono = input.Cellphone,
                correo = input.Email,
                idDireccion = input.Address,
                idTipoDocumento = input.IdentificationType
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
