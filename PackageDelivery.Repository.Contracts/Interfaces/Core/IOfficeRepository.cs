using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Core
{
    public interface IOfficeRepository
    {
        OfficeDbModel getRecordById(int id);
        IEnumerable<OfficeDbModel> getRecordsList(string filter);
        OfficeDbModel createRecord(OfficeDbModel record);
        OfficeDbModel updateRecord(OfficeDbModel record);
        bool deleteRecordById(int id);
    }
}
