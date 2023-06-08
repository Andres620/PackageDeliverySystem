using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Core;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Implementation.Core
{
    public class PackageImpRepository : IPackageRepository
    {
        public PackageDbModel createRecord(PackageDbModel record)
        {
			using (PackageDeliveryEntities db = new PackageDeliveryEntities())
			{
				paquete package = db.paquete.Where(x => x.id == record.Id).FirstOrDefault();
				if (package != null)
				{
					return null;
				}
				PackageRepositoryMapper mapper = new PackageRepositoryMapper();
				paquete pk = mapper.DbModelToDatabaseMapper(record);
				db.paquete.Add(pk);
				db.SaveChanges();
				return mapper.DatabaseToDbModelMapper(pk);
			}
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

        public IEnumerable<PackageDbModel> getRecordsList()
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<paquete> list = db.paquete.Where(x => x.id != null);
                PackageRepositoryMapper mapper = new PackageRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public PackageDbModel updateRecord(PackageDbModel record)
        {
			using (PackageDeliveryEntities db = new PackageDeliveryEntities())
			{
				paquete package = db.paquete.Where(x => x.id == record.Id).FirstOrDefault();
				if (package == null)
				{
					return null;
				}
				else
				{
                    package.peso = record.weight;
					package.altura = record.height;
                    package.profundidad = record.depth;
                    package.ancho = record.width;
                    package.idOficina = record.idOffice;
					db.Entry(package).State = EntityState.Modified;
					db.SaveChanges();
					PackageRepositoryMapper mapper = new PackageRepositoryMapper();

					return mapper.DatabaseToDbModelMapper(package);
				}
			}
		}
    }
}
