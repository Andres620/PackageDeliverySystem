
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class ShipmentRepositoryMapper : DbModelMapperBase<ShipmentDbModel, envio>
    {
        public override ShipmentDbModel DatabaseToDbModelMapper(envio input)
        {
            return new ShipmentDbModel()
            {
                Id = (int)input.id,
                idDestinationAddress = (int)input.idDireccionDestino,
                price = (int)input.precio,
                shippingDate = input.fechaEnvio,
                idPackage = (int)input.idPaquete,
                idSender = (int)input.idRemitente,
                idShipmentState = (int)input.idEstado,
                idTransportType = (int)input.idTipoTransporte
            };
        }

        public override IEnumerable<ShipmentDbModel> DatabaseToDbModelMapper(IEnumerable<envio> input)
        {
            IList<ShipmentDbModel> list = new List<ShipmentDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override envio DbModelToDatabaseMapper(ShipmentDbModel input)
        {
            return new envio()
            {
                id = input.Id,
                idDireccionDestino = input.idDestinationAddress,
                precio = input.price,
                fechaEnvio = input.shippingDate,
                idPaquete = input.idPackage,
                idRemitente = input.idSender,
                idEstado = input.idShipmentState,
                idTipoTransporte = input.idTransportType
            };
        }

        public override IEnumerable<envio> DbModelToDatabaseMapper(IEnumerable<ShipmentDbModel> input)
        {
            IList<envio> list = new List<envio>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
