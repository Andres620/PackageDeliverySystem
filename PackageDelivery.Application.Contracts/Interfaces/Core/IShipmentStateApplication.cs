using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Core
{
    public interface IShipmentStateApplication
    {
        ShipmentStateDTO getRecordById(int id);
        IEnumerable<ShipmentStateDTO> getRecordsList();
        ShipmentStateDTO createRecord(ShipmentStateDTO record);
        ShipmentStateDTO updateRecord(ShipmentStateDTO record);
        bool deleteRecordById(int id);
    }
}
