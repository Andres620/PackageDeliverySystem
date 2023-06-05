using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Core
{
    public interface IPackageApplication
    {
        PackageDTO getRecordById(int id);
        IEnumerable<PackageDTO> getRecordsList();
        PackageDTO createRecord(PackageDTO record);
        PackageDTO updateRecord(PackageDTO record);
        bool deleteRecordById(int id);
    }
}
