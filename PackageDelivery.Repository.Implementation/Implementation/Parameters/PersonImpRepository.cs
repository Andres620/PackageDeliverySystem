using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Implementation.Parameters
{
    public class PersonImpRepository : IPersonRepository
    {
        public PersonDbModel createRecord(PersonDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                persona personType = db.persona.Where(x => x.documento.Equals(record.IdentificationNumber)).FirstOrDefault();
                if (personType != null)
                {
                    return null;
                }
                PersonRepositoryMapper mapper = new PersonRepositoryMapper();
                persona dt = mapper.DbModelToDatabaseMapper(record);
                db.persona.Add(dt);
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
                    persona record = db.persona.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.persona.Remove(record);
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
        public PersonDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                persona record = db.persona.Find(id);
                if (record == null)
                {
                    return null;
                }
                PersonRepositoryMapper mapper = new PersonRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<PersonDbModel> getRecordsList()
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<persona> list = db.persona.Where(x => x.id != null);
                PersonRepositoryMapper mapper = new PersonRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public PersonDbModel updateRecord(PersonDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                persona td = db.persona.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.primerNombre = record.FirstName;
                    td.otrosNombres = record.OtherNames;
                    td.primerApellido = record.FirstLastname;
                    td.segundoApellido = record.SecondLastname;
                    td.correo = record.Email;
                    td.idTipoDocumento = record.IdDocumentType;
                    td.documento = record.IdentificationNumber;
                    td.telefono = record.Cellphone;
                    td.idDireccion = record.Address;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    PersonRepositoryMapper mapper = new PersonRepositoryMapper();

                    return mapper.DatabaseToDbModelMapper(td);
                }
            }
        }
    }
}
