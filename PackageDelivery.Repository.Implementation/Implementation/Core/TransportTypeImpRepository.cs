using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Core;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Implementation.Core
{
    public class TransportTypeImpRepository : ITransportTypeRepository
    {
        public TransportTypeDbModel createRecord(TransportTypeDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                tipoTransporte transportType = db.tipoTransporte.Where(x => x.nombre.ToUpper().Trim().Equals(record.name.ToUpper())).FirstOrDefault();
                if (transportType != null)
                {
                    return null;
                }
                TransportTypeRepositoryMapper mapper = new TransportTypeRepositoryMapper();
                tipoTransporte dt = mapper.DbModelToDatabaseMapper(record);
                db.tipoTransporte.Add(dt);
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
                    tipoTransporte record = db.tipoTransporte.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.tipoTransporte.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public TransportTypeDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                tipoTransporte record = db.tipoTransporte.Find(id);
                if (record == null)
                {
                    return null;
                }
                TransportTypeRepositoryMapper mapper = new TransportTypeRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        public IEnumerable<TransportTypeDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<tipoTransporte> list = db.tipoTransporte.Where(x => x.nombre.Contains(filter));
                TransportTypeRepositoryMapper mapper = new TransportTypeRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public TransportTypeDbModel updateRecord(TransportTypeDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                tipoTransporte td = db.tipoTransporte.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.nombre = record.name;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    TransportTypeRepositoryMapper mapper = new TransportTypeRepositoryMapper();
                    return mapper.DatabaseToDbModelMapper(td);
                }
            }
        }
    }
}
