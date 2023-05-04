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
    public class WarehouseImpRepository : IWarehouseRepository
    {
        public WarehouseDbModel createRecord(WarehouseDbModel record)
        {
            throw new NotImplementedException();
        }

        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    bodega record = db.bodega.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.bodega.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public WarehouseDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                bodega record = db.bodega.Find(id);
                if (record == null)
                {
                    return null;
                }
                WarehouseRepositoryMapper mapper = new WarehouseRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        public IEnumerable<WarehouseDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<bodega> list = db.bodega.Where(x => x.nombre.Contains(filter));
                WarehouseRepositoryMapper mapper = new WarehouseRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public WarehouseDbModel updateRecord(WarehouseDbModel record)
        {
            throw new NotImplementedException();
        }
    }
}
