using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Implementation.Parameters
{
    public class TownImpRepository : ITownRepository
    {
        public TownDbModel createRecord(TownDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                municipio townType = db.municipio.Where(x => x.nombre.ToUpper().Trim().Equals(record.name.ToUpper())).FirstOrDefault();
                if (townType != null)
                {
                    return null;
                }
                TownRepositoryMapper mapper = new TownRepositoryMapper();
                municipio dt = mapper.DbModelToDatabaseMapper(record);
                db.municipio.Add(dt);
                db.SaveChanges();
                return mapper.DatabaseToDbModelMapper(dt);
            }
        }

        /// <summary>
        /// Eliminación de un registro en la base de datos por Id
        /// </summary>
        /// <param name="id">Id del registro a eliminar</param>
        /// <returns>Booleano, true cuando se elimina y false cuando no se encuentra o está asociado como FK</returns>
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

        /// <summary>
        /// Obtiene el registro por Id
        /// </summary>
        /// <param name="id">Id del registro a buscar</param>
        /// <returns>null cuando no lo encuentra o el objeto cunado si lo encuentra</returns>
        public TownDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                municipio record = db.municipio.Find(id);
                if (record == null)
                {
                    return null;
                }
                TownRepositoryMapper mapper = new TownRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<TownDbModel> getRecordsList()
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<municipio> list = db.municipio.Where(x => x.id != null);
                TownRepositoryMapper mapper = new TownRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public TownDbModel updateRecord(TownDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                municipio td = db.municipio.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.nombre = record.name;
                    td.idDepartamento = record.IdDepartment;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    TownRepositoryMapper mapper = new TownRepositoryMapper();

                    return mapper.DatabaseToDbModelMapper(td);
                }
            }
        }
    }
}
