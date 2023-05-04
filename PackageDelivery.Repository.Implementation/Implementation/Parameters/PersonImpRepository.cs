using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Implementation.Parameters
{
    public class PersonImpRepository : IPersonRepository
    {
        public PersonDbModel createRecord(PersonDbModel record)
        {
            throw new NotImplementedException();
        }

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

        public IEnumerable<PersonDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<persona> list = db.persona.Where(x => x.primerNombre.Contains(filter));
                PersonRepositoryMapper mapper = new PersonRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public PersonDbModel updateRecord(PersonDbModel record)
        {
            throw new NotImplementedException();
        }
    }
}
