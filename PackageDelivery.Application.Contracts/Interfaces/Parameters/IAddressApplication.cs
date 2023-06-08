using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IAddressApplication
    {
        AddressDTO getRecordById(int id);
        IEnumerable<AddressDTO> getRecordsList();
        AddressDTO createRecord(AddressDTO record);
        AddressDTO updateRecord(AddressDTO record);
        bool deleteRecordById(int id);
    }
}
