using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Implementation.Parameters
{
    public class DepartmentImpRepository : IDepartmentRepository
    {
        public DepartmentDbModel createRecord(DepartmentDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                departamento deptType = db.departamento.Where(x => x.nombre.ToUpper().Trim().Equals(record.name.ToUpper())).FirstOrDefault();
                if (deptType != null)
                {
                    return null;
                }
                DepartmentRepositoryMapper mapper = new DepartmentRepositoryMapper();
                departamento dt = mapper.DbModelToDatabaseMapper(record);
                db.departamento.Add(dt);
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
                    departamento record = db.departamento.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.departamento.Remove(record);
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
        public DepartmentDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                departamento record = db.departamento.Find(id);
                if (record == null)
                {
                    return null;
                }
                DepartmentRepositoryMapper mapper = new DepartmentRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<DepartmentDbModel> getRecordsList()
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<departamento> list = db.departamento.Where(x => x.id != null);
                DepartmentRepositoryMapper mapper = new DepartmentRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public DepartmentDbModel updateRecord(DepartmentDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                departamento td = db.departamento.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.nombre = record.name;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    DepartmentRepositoryMapper mapper = new DepartmentRepositoryMapper();
                    return mapper.DatabaseToDbModelMapper(td);
                }
            }
        }
    }
}
