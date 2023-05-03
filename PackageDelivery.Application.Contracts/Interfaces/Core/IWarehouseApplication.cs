using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Core
{
    public interface IWarehouseApplication
    {
        WarehouseDTO getRecordById(int id);
        IEnumerable<WarehouseDTO> getRecordsList(string filter);
        WarehouseDTO createRecord(WarehouseDTO record);
        WarehouseDTO updateRecord(WarehouseDTO record);
        bool deleteRecordById(int id);
    }
}
