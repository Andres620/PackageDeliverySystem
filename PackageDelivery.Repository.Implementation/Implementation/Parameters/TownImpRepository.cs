using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Implementation.Parameters
{
    public class TownImpRepository : ITownRepository
    {
        public TownDbModel createRecord(TownDbModel record)
        {
            throw new NotImplementedException();
        }

        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    municipio record = db.municipio.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.municipio.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public TownDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                municipio record = db.municipio.Find(id);
                if (record == null)
                {
                    return null;
                }
                TowmRepositoryMapper mapper = new TowmRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        public IEnumerable<TownDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<municipio> list = db.municipio.Where(x => x.nombre.Contains(filter));
                TowmRepositoryMapper mapper = new TowmRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public TownDbModel updateRecord(TownDbModel record)
        {
            throw new NotImplementedException();
        }
    }
}
