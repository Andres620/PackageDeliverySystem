using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Implementation.Parameters
{
    public class AddressImpRepository : IAddressRepository
    {
        public AddressDbModel createRecord(AddressDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            { 
                AddressRepositoryMapper mapper = new AddressRepositoryMapper();
                direccion dt = mapper.DbModelToDatabaseMapper(record);
                db.direccion.Add(dt);
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

        /// <summary>
        /// Obtiene el registro por Id
        /// </summary>
        /// <param name="id">Id del registro a buscar</param>
        /// <returns>null cuando no lo encuentra o el objeto cunado si lo encuentra</returns>
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

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<AddressDbModel> getRecordsList()
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<direccion> list = db.direccion.Where(x => x.id != null);
                AddressRepositoryMapper mapper = new AddressRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public AddressDbModel updateRecord(AddressDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                direccion td = db.direccion.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.tipoCalle = record.streetType;
                    td.numero = record.number;
                    td.tipoInmueble = record.immovableType;
                    td.barrio = record.neighborhood;
                    td.observaciones = record.observations;
                    td.actual = record.actual;
                    td.idMunicipio = record.IdTown;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    AddressRepositoryMapper mapper = new AddressRepositoryMapper();
                    return mapper.DatabaseToDbModelMapper(td);
                }
            }
        }
    }
}
