
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class WarehouseRepositoryMapper : DbModelMapperBase<WarehouseDbModel, bodega>
    {
        public override WarehouseDbModel DatabaseToDbModelMapper(bodega input)
        {
            return new WarehouseDbModel()
            {
                Id = (int)input.id,
                address = input.direccion,
                code = input.codigo,
                idTown = (int)input.idMunicipio,
                latitude = input.latitud,
                longitude = input.longitud,
                name = input.nombre
            };
        }

        public override IEnumerable<WarehouseDbModel> DatabaseToDbModelMapper(IEnumerable<bodega> input)
        {
            IList<WarehouseDbModel> list = new List<WarehouseDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override bodega DbModelToDatabaseMapper(WarehouseDbModel input)
        {
            return new bodega()
            {
                id = (int)input.Id,
                direccion = input.address,
                codigo = input.code,
                idMunicipio = input.idTown,
                latitud = input.latitude,
                longitud = input.longitude,
                nombre = input.name
            };
        }

        public override IEnumerable<bodega> DbModelToDatabaseMapper(IEnumerable<WarehouseDbModel> input)
        {
            IList<bodega> list = new List<bodega>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}