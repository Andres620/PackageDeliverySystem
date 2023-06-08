using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Core
{
    public interface IVehicleApplication
    {
        VehicleDTO getRecordById(int id);
        IEnumerable<VehicleDTO> getRecordsList();
        VehicleDTO createRecord(VehicleDTO record);
        VehicleDTO updateRecord(VehicleDTO record);
        bool deleteRecordById(int id);
    }
}
