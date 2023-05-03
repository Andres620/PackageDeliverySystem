using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Core
{
    public interface IOfficeApplication
    {
        OfficeDTO getRecordById(int id);
        IEnumerable<OfficeDTO> getRecordsList(string filter);
        OfficeDTO createRecord(OfficeDTO record);
        OfficeDTO updateRecord(OfficeDTO record);
        bool deleteRecordById(int id);
    }
}
