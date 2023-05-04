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
    public class VehicleImpRepository : IVehicleRepository
    {
        public VehicleDbModel createRecord(VehicleDbModel record)
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

        public VehicleDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                vehiculo record = db.vehiculo.Find(id);
                if (record == null)
                {
                    return null;
                }
                VehicleRepositoryMapper mapper = new VehicleRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        public IEnumerable<VehicleDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<vehiculo> list = db.vehiculo.Where(x => x.placa.Contains(filter));
                VehicleRepositoryMapper mapper = new VehicleRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public VehicleDbModel updateRecord(VehicleDbModel record)
        {
            throw new NotImplementedException();
        }
    }
}
