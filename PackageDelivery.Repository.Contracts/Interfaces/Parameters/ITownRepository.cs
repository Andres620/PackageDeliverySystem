using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface ITownRepository
    {
        TownDbModel getRecordById(int id);
        IEnumerable<TownDbModel> getRecordsList();
        TownDbModel createRecord(TownDbModel record);
        TownDbModel updateRecord(TownDbModel record);
        bool deleteRecordById(int id);
    }
}
