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
    public class HistoryImpRepository : IHistoryRepository
    {
        public HistoryDbModel createRecord(HistoryDbModel record)
        {
            throw new NotImplementedException();
        }

        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    historial record = db.historial.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.historial.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public HistoryDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                historial record = db.historial.Find(id);
                if (record == null)
                {
                    return null;
                }
                HistoryRepositoryMapper mapper = new HistoryRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        public IEnumerable<HistoryDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<historial> list = db.historial.Where(x => x.descripcion.Contains(filter));
                HistoryRepositoryMapper mapper = new HistoryRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public HistoryDbModel updateRecord(HistoryDbModel record)
        {
            throw new NotImplementedException();
        }
    }
}
