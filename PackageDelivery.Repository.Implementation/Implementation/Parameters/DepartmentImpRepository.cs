using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Implementation.Parameters
{
    public class DepartmentImpRepository : IDepartmentRepository
    {
        public DepartmentDbModel createRecord(DepartmentDbModel record)
        {
            throw new NotImplementedException();
        }

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

        public IEnumerable<DepartmentDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<departamento> list = db.departamento.Where(x => x.nombre.Contains(filter));
                DepartmentRepositoryMapper mapper = new DepartmentRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public DepartmentDbModel updateRecord(DepartmentDbModel record)
        {
            throw new NotImplementedException();
        }
    }
}
