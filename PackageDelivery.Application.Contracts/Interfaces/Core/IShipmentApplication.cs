using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Core
{
    public interface IShipmentApplication
    {
        ShipmentDTO getRecordById(int id);
        IEnumerable<ShipmentDTO> getRecordsList();
        ShipmentDTO createRecord(ShipmentDTO record);
        ShipmentDTO updateRecord(ShipmentDTO record);
        bool deleteRecordById(int id);
    }
}
