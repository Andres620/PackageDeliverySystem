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
    public class PackageImpRepository : IPackageRepository
    {
        public PackageDbModel createRecord(PackageDbModel record)
        {
            throw new NotImplementedException();
        }

        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    paquete record = db.paquete.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.paquete.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public PackageDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                paquete record = db.paquete.Find(id);
                if (record == null)
                {
                    return null;
                }
                PackageRepositoryMapper mapper = new PackageRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        public IEnumerable<PackageDbModel> getRecordsList(double filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<paquete> list = db.paquete.Where(x => x.peso == filter);
                PackageRepositoryMapper mapper = new PackageRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public PackageDbModel updateRecord(PackageDbModel record)
        {
            throw new NotImplementedException();
        }
    }
}
