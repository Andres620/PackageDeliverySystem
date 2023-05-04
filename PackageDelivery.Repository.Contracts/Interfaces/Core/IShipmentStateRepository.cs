using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Core
{
    public interface IShipmentStateRepository
    {
        ShipmentStateDbModel getRecordById(int id);
        IEnumerable<ShipmentStateDbModel> getRecordsList(string filter);
        ShipmentStateDbModel createRecord(ShipmentStateDbModel record);
        ShipmentStateDbModel updateRecord(ShipmentStateDbModel record);
        bool deleteRecordById(int id);
    }
}
