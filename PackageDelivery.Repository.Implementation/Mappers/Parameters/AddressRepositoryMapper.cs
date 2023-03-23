using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class AddressRepositoryMapper : DbModelMapperBase<AddressDbModel, direccion>
    {
        public override AddressDbModel DatabaseToDbModelMapper(direccion input)
        {
            return new AddressDbModel()
            {
                Id = input.id,
                actual = input.actual,
                IdPerson = (int)input.idPersona,
                IdTown = (int)input.idMunicipio,
                immovableType = input.tipoInmueble,
                neighborhood = input.barrio,
                number = input.numero,
                observations = input.observaciones,
                streetType = input.tipoCalle
            };
        }

        public override IEnumerable<AddressDbModel> DatabaseToDbModelMapper(IEnumerable<direccion> input)
        {
            IList<AddressDbModel> list = new List<AddressDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override direccion DbModelToDatabaseMapper(AddressDbModel input)
        {
            return new direccion()
            {
                id = input.Id,
                idPersona = input.IdPerson,
                idMunicipio = input.IdTown,
                actual = input.actual,
                barrio = input.neighborhood,
                observaciones = input.observations,
                numero = input.number,
                tipoInmueble = input.immovableType,
                tipoCalle = input.streetType
            };
        }

        public override IEnumerable<direccion> DbModelToDatabaseMapper(IEnumerable<AddressDbModel> input)
        {
            IList<direccion> list = new List<direccion>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
