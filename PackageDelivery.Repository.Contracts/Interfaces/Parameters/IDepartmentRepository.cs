using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IDepartmentRepository
    {
        DepartmentDbModel getRecordById(int id);
        IEnumerable<DepartmentDbModel> getRecordsList();
        DepartmentDbModel createRecord(DepartmentDbModel record);
        DepartmentDbModel updateRecord(DepartmentDbModel record);
        bool deleteRecordById(int id);
    }
}
