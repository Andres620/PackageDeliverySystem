using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IDepartmentApplication
    {
        DepartmentDTO getRecordById(int id);
        IEnumerable<DepartmentDTO> getRecordsList();
        DepartmentDTO createRecord(DepartmentDTO record);
        DepartmentDTO updateRecord(DepartmentDTO record);
        bool deleteRecordById(int id);
    }
}
