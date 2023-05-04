using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Core
{
    public interface IVehicleRepository
    {
        VehicleDbModel getRecordById(int id);
        IEnumerable<VehicleDbModel> getRecordsList(string filter);
        VehicleDbModel createRecord(VehicleDbModel record);
        VehicleDbModel updateRecord(VehicleDbModel record);
        bool deleteRecordById(int id);
    }
}
