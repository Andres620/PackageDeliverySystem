using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository_Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class ShipmentStateRepositoryMapper : DbModelMapperBase<ShipmentStateDbModel, estadoEnvio>
    {
        public override ShipmentStateDbModel DatabaseToDbModelMapper(estadoEnvio input)
        {
            return new ShipmentStateDbModel()
            {
                Id = (int)input.id,
                name = input.nombre
            };
        }

        public override IEnumerable<ShipmentStateDbModel> DatabaseToDbModelMapper(IEnumerable<estadoEnvio> input)
        {
            IList<ShipmentStateDbModel> list = new List<ShipmentStateDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override estadoEnvio DbModelToDatabaseMapper(ShipmentStateDbModel input)
        {
            return new estadoEnvio()
            {
                id = input.Id,
                nombre = input.name
            };
        }

        public override IEnumerable<estadoEnvio> DbModelToDatabaseMapper(IEnumerable<ShipmentStateDbModel> input)
        {
            IList<estadoEnvio> list = new List<estadoEnvio>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
