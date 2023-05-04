using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Core
{
    public interface IPackageRepository
    {
        PackageDbModel getRecordById(int id);
        IEnumerable<PackageDbModel> getRecordsList(double filter);
        PackageDbModel createRecord(PackageDbModel record);
        PackageDbModel updateRecord(PackageDbModel record);
        bool deleteRecordById(int id);
    }
}
