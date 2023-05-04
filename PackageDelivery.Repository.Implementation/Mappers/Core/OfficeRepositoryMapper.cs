
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class OfficeRepositoryMapper : DbModelMapperBase<OfficeDbModel, oficina>
    {
        public override OfficeDbModel DatabaseToDbModelMapper(oficina input)
        {
            return new OfficeDbModel()
            {
                Id = (int)input.id,
                address = input.direccion,
                cellphone = input.telefono,
                code = input.codigo,
                idTown = (int)input.idMunicipio,
                latitude = input.latitud,
                longitude = input.longitud,
                name = input.nombre
            };
        }

        public override IEnumerable<OfficeDbModel> DatabaseToDbModelMapper(IEnumerable<oficina> input)
        {
            IList<OfficeDbModel> list = new List<OfficeDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override oficina DbModelToDatabaseMapper(OfficeDbModel input)
        {
            return new oficina()
            {
                id = input.Id,
                direccion = input.address,
                telefono = input.cellphone,
                codigo = input.code,
                idMunicipio = input.idTown,
                latitud = input.latitude,
                longitud = input.longitude,
                nombre = input.name
            };
        }

        public override IEnumerable<oficina> DbModelToDatabaseMapper(IEnumerable<OfficeDbModel> input)
        {
            IList<oficina> list = new List<oficina>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}