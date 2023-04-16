
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository_Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class VehicleRepositoryMapper : DbModelMapperBase<VehicleDbModel, vehiculo>
    {
        public override VehicleDbModel DatabaseToDbModelMapper(vehiculo input)
        {
            return new VehicleDbModel()
            {
                Id = (int)input.id,
                plate = input.placa,
                idTransportType = (int)input.idTipoTransporte
            };
        }

        public override IEnumerable<VehicleDbModel> DatabaseToDbModelMapper(IEnumerable<vehiculo> input)
        {
            IList<VehicleDbModel> list = new List<VehicleDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override vehiculo DbModelToDatabaseMapper(VehicleDbModel input)
        {
            return new vehiculo()
            {
                id = input.Id,
                placa = input.plate,
                idTipoTransporte = input.idTransportType
            };
        }

        public override IEnumerable<vehiculo> DbModelToDatabaseMapper(IEnumerable<VehicleDbModel> input)
        {
            IList<vehiculo> list = new List<vehiculo>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}