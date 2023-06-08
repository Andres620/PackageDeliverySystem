using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Core
{
    public interface ITransportTypeApplication
    {
        TransportTypeDTO getRecordById(int id);
        IEnumerable<TransportTypeDTO> getRecordsList();
        TransportTypeDTO createRecord(TransportTypeDTO record);
        TransportTypeDTO updateRecord(TransportTypeDTO record);
        bool deleteRecordById(int id);
    }
}
