using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Core
{
    public interface IShipmentRepository
    {
        ShipmentDbModel getRecordById(int id);
        IEnumerable<ShipmentDbModel> getRecordsList(long filter);
        ShipmentDbModel createRecord(ShipmentDbModel record);
        ShipmentDbModel updateRecord(ShipmentDbModel record);
        bool deleteRecordById(int id);
    }
}
