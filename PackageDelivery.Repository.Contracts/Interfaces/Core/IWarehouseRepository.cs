using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Core
{
    public interface IWarehouseRepository
    {
        WarehouseDbModel getRecordById(int id);
        IEnumerable<WarehouseDbModel> getRecordsList(string filter);
        WarehouseDbModel createRecord(WarehouseDbModel record);
        WarehouseDbModel updateRecord(WarehouseDbModel record);
        bool deleteRecordById(int id);
    }
}
