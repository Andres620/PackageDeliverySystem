using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Core;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Implementation.Core
{
    public class VehicleImpRepository : IVehicleRepository
    {
        public VehicleDbModel createRecord(VehicleDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                vehiculo vehicleType = db.vehiculo.Where(x => x.placa.ToUpper().Trim().Equals(record.plate.ToUpper())).FirstOrDefault();
                if (vehicleType != null)
                {
                    return null;
                }
                VehicleRepositoryMapper mapper = new VehicleRepositoryMapper();
                vehiculo dt = mapper.DbModelToDatabaseMapper(record);
                db.vehiculo.Add(dt);
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

        public IEnumerable<VehicleDbModel> getRecordsList()
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<vehiculo> list = db.vehiculo.Where(x => x.id != null);
                VehicleRepositoryMapper mapper = new VehicleRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public VehicleDbModel updateRecord(VehicleDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                vehiculo td = db.vehiculo.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.placa = record.plate;
                    td.idTipoTransporte = record.idTransportType;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    VehicleRepositoryMapper mapper = new VehicleRepositoryMapper();
                    return mapper.DatabaseToDbModelMapper(td);
                }
            }
        }
    }
}
