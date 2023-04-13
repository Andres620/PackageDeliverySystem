using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IPersonApplication
    {
        PersonDTO getRecordById(int id);
        IEnumerable<PersonDTO> getRecordsList(string filter);
        PersonDTO createRecord(PersonDTO record);
        PersonDTO updateRecord(PersonDTO record);
        bool deleteRecordById(int id);
    }
}
