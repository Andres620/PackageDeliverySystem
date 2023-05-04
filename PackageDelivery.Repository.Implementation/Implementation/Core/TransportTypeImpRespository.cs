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
    public class TransportTypeImpRespository : ITransportTypeRepository
    {
        public TransportTypeDbModel createRecord(TransportTypeDbModel record)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
