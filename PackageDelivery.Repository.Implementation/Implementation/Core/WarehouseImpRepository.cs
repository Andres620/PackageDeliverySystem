using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Core;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Implementation.Core
{
    public class WarehouseImpRepository : IWarehouseRepository
    {
        public WarehouseDbModel createRecord(WarehouseDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                bodega warehouseType = db.bodega.Where(x => x.nombre.ToUpper().Trim().Equals(record.name.ToUpper())).FirstOrDefault();
                if (warehouseType != null)
                {
                    return null;
                }
                WarehouseRepositoryMapper mapper = new WarehouseRepositoryMapper();
                bodega dt = mapper.DbModelToDatabaseMapper(record);
                db.bodega.Add(dt);
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

        public IEnumerable<WarehouseDbModel> getRecordsList()
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<bodega> list = db.bodega.Where(x => x.id != null);
                WarehouseRepositoryMapper mapper = new WarehouseRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public WarehouseDbModel updateRecord(WarehouseDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                bodega td = db.bodega.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.nombre = record.name;
                    td.codigo = record.code;
                    td.direccion = record.address;
                    td.latitud = record.latitude;
                    td.longitud = record.longitude;
                    td.idMunicipio = record.idTown;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    WarehouseRepositoryMapper mapper = new WarehouseRepositoryMapper();
                    return mapper.DatabaseToDbModelMapper(td);
                }
            }
        }
    }
}
