using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface ITownApplication
    {
        TownDTO getRecordById(int id);
        IEnumerable<TownDTO> getRecordsList(string filter);
        TownDTO createRecord(TownDTO record);
        TownDTO updateRecord(TownDTO record);
        bool deleteRecordById(int id);
    }
}
