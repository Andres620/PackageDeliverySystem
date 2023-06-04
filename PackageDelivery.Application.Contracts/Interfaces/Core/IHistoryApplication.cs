using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Core
{
    public interface IHistoryApplication
    {
        HistoryDTO getRecordById(int id);
        IEnumerable<HistoryDTO> getRecordsList();
        HistoryDTO createRecord(HistoryDTO record);
        HistoryDTO updateRecord(HistoryDTO record);
        bool deleteRecordById(int id);
    }
}
