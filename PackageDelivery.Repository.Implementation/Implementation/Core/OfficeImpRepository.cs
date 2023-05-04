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
    public class OfficeImpRepository : IOfficeRepository
    {
        public OfficeDbModel createRecord(OfficeDbModel record)
        {
            throw new NotImplementedException();
        }

        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    oficina record = db.oficina.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.oficina.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public OfficeDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                oficina record = db.oficina.Find(id);
                if (record == null)
                {
                    return null;
                }
                OfficeRepositoryMapper mapper = new OfficeRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        public IEnumerable<OfficeDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<oficina> list = db.oficina.Where(x => x.direccion.Contains(filter));
                OfficeRepositoryMapper mapper = new OfficeRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public OfficeDbModel updateRecord(OfficeDbModel record)
        {
            throw new NotImplementedException();
        }
    }
}
