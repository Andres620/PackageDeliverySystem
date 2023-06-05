using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Core;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Implementation.Core
{
    public class ShipmentImpRepository : IShipmentRepository
    {
        public ShipmentDbModel createRecord(ShipmentDbModel record)
        {
			using (PackageDeliveryEntities db = new PackageDeliveryEntities())
			{
				envio shipment = db.envio.Where(x => x.idPaquete == record.idPackage).FirstOrDefault();
				if (shipment != null)
				{
					return null;
				}
				ShipmentRepositoryMapper mapper = new ShipmentRepositoryMapper();
				envio sh = mapper.DbModelToDatabaseMapper(record);
				db.envio.Add(sh);
				db.SaveChanges();
				return mapper.DatabaseToDbModelMapper(sh);
			}
		}

        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    envio record = db.envio.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.envio.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public ShipmentDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                envio record = db.envio.Find(id);
                if (record == null)
                {
                    return null;
                }
                ShipmentRepositoryMapper mapper = new ShipmentRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        public IEnumerable<ShipmentDbModel> getRecordsList()
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<envio> list = db.envio.Where(x => x.id != null);
                ShipmentRepositoryMapper mapper = new ShipmentRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public ShipmentDbModel updateRecord(ShipmentDbModel record)
        {
			using (PackageDeliveryEntities db = new PackageDeliveryEntities())
			{
				envio shipment = db.envio.Where(x => x.id == record.Id).FirstOrDefault();
				if (shipment == null)
				{
					return null;
				}
				else
				{
                    shipment.fechaEnvio = record.shippingDate;
					shipment.precio = record.price;
                    shipment.idRemitente = record.idSender;
                    shipment.idDireccionDestino = record.idDestinationAddress;
                    shipment.idPaquete = record.idPackage;
                    shipment.idEstado = record.idShipmentState;
                    shipment.idTipoTransporte = record.idTransportType;

					db.Entry(shipment).State = EntityState.Modified;
					db.SaveChanges();
					ShipmentRepositoryMapper mapper = new ShipmentRepositoryMapper();

					return mapper.DatabaseToDbModelMapper(shipment);
				}
			}
		}
    }
}
