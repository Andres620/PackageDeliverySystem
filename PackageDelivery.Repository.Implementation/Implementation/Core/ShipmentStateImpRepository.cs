using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Core;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Implementation.Core
{
    public class ShipmentStateImpRepository : IShipmentStateRepository
    {
        public ShipmentStateDbModel createRecord(ShipmentStateDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                estadoEnvio shipmentStateType = db.estadoEnvio.Where(x => x.nombre.ToUpper().Trim().Equals(record.name.ToUpper())).FirstOrDefault();
                if (shipmentStateType != null)
                {
                    return null;
                }
                ShipmentStateRepositoryMapper mapper = new ShipmentStateRepositoryMapper();
                estadoEnvio dt = mapper.DbModelToDatabaseMapper(record);
                db.estadoEnvio.Add(dt);
                db.SaveChanges();
                return mapper.DatabaseToDbModelMapper(dt);
            }
        }

        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    estadoEnvio record = db.estadoEnvio.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.estadoEnvio.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public ShipmentStateDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                estadoEnvio record = db.estadoEnvio.Find(id);
                if (record == null)
                {
                    return null;
                }
                ShipmentStateRepositoryMapper mapper = new ShipmentStateRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        public IEnumerable<ShipmentStateDbModel> getRecordsList(string filter)
        {
            {
                using (PackageDeliveryEntities db = new PackageDeliveryEntities())
                {
                    IEnumerable<estadoEnvio> list = db.estadoEnvio.Where(x => x.nombre.Contains(filter));
                    ShipmentStateRepositoryMapper mapper = new ShipmentStateRepositoryMapper();
                    return mapper.DatabaseToDbModelMapper(list);
                }
            }

        }

        public ShipmentStateDbModel updateRecord(ShipmentStateDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                estadoEnvio td = db.estadoEnvio.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.nombre = record.name;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    ShipmentStateRepositoryMapper mapper = new ShipmentStateRepositoryMapper();
                    return mapper.DatabaseToDbModelMapper(td);
                }
            }
        }

    }
}
