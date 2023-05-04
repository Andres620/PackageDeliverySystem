using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Core
{
    public interface IHistoryRepository
    {
        HistoryDbModel getRecordById(int id);
        IEnumerable<HistoryDbModel> getRecordsList(string filter);
        HistoryDbModel createRecord(HistoryDbModel record);
        HistoryDbModel updateRecord(HistoryDbModel record);
        bool deleteRecordById(int id);
    }
}
