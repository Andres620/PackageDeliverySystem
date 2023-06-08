using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Parameters
{
    public class DocumentTypeImpRepository : IDocumentTypeRepository
    {
        public DocumentTypeDbModel createRecord(DocumentTypeDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                tipoDocumento docType = db.tipoDocumento.Where(x => x.nombre.ToUpper().Trim().Equals(record.Name.ToUpper())).FirstOrDefault();
                if (docType != null)
                {
                    return null;
                }
                DocumentTypeRepositoryMapper mapper = new DocumentTypeRepositoryMapper();
                tipoDocumento dt = mapper.DbModelToDatabaseMapper(record);
                db.tipoDocumento.Add(dt);
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
                    tipoDocumento record = db.tipoDocumento.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.tipoDocumento.Remove(record);
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
        public DocumentTypeDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                tipoDocumento record = db.tipoDocumento.Find(id);
                if (record == null)
                {
                    return null;
                }
                DocumentTypeRepositoryMapper mapper = new DocumentTypeRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<DocumentTypeDbModel> getRecordsList()
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<tipoDocumento> list = db.tipoDocumento.Where(x => x.id != null);
                DocumentTypeRepositoryMapper mapper = new DocumentTypeRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public DocumentTypeDbModel updateRecord(DocumentTypeDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                tipoDocumento td = db.tipoDocumento.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.nombre = record.Name;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    DocumentTypeRepositoryMapper mapper = new DocumentTypeRepositoryMapper();

                    return mapper.DatabaseToDbModelMapper(td);
                }
            }
        }
    }
}
