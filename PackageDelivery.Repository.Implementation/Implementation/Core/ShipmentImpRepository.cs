using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Core;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Implementation.Core
{
    public class ShipmentImpRepository : IShipmentRepository
    {
        public ShipmentDbModel createRecord(ShipmentDbModel record)
        {
            throw new NotImplementedException();
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

        public IEnumerable<ShipmentDbModel> getRecordsList(long filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<envio> list = db.envio.Where(x => x.idPaquete == filter);
                ShipmentRepositoryMapper mapper = new ShipmentRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public ShipmentDbModel updateRecord(ShipmentDbModel record)
        {
            throw new NotImplementedException();
        }
    }
}
