using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces.Core;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Implementation.Core
{
    public class HistoryImpRepository : IHistoryRepository
    {
        public HistoryDbModel createRecord(HistoryDbModel record)
        {
			using (PackageDeliveryEntities db = new PackageDeliveryEntities())
			{
				historial history = db.historial.Where(x => x.idPaquete == record.idPackage).FirstOrDefault();
				if (history != null)
				{
					return null;
				}
				HistoryRepositoryMapper mapper = new HistoryRepositoryMapper();
				historial hs = mapper.DbModelToDatabaseMapper(record);
				db.historial.Add(hs);
				db.SaveChanges();
				return mapper.DatabaseToDbModelMapper(hs);
			}
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
			using (PackageDeliveryEntities db = new PackageDeliveryEntities())
			{
				historial history = db.historial.Where(x => x.id == record.Id).FirstOrDefault();
				if (history == null)
				{
					return null;
				}
				else
				{
                    history.fechaIngreso = record.entryDate;
                    history.fechaSalida = record.departureDate;
					history.descripcion = record.description;
                    history.idPaquete = record.idPackage;
                    history.idBodega = record.idWarehouse;
					db.Entry(history).State = EntityState.Modified;
					db.SaveChanges();
					HistoryRepositoryMapper mapper = new HistoryRepositoryMapper();

					return mapper.DatabaseToDbModelMapper(history);
				}
			}
		}
    }
}
