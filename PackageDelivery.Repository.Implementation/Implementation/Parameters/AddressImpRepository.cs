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
    public class AddressImpRepository : IAddressRepository
    {
        public AddressDbModel createRecord(AddressDbModel record)
        {
            throw new NotImplementedException();
        }

        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    direccion record = db.direccion.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.direccion.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public AddressDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                direccion record = db.direccion.Find(id);
                if (record == null)
                {
                    return null;
                }
                AddressRepositoryMapper mapper = new AddressRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        public IEnumerable<AddressDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<direccion> list = db.direccion.Where(x => x.observaciones.Contains(filter));
                AddressRepositoryMapper mapper = new AddressRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public AddressDbModel updateRecord(AddressDbModel record)
        {
            throw new NotImplementedException();
        }
    }
}
