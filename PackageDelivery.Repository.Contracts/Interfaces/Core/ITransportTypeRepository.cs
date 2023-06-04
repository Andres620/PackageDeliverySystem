using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Core
{
    public interface ITransportTypeRepository
    {
        TransportTypeDbModel getRecordById(int id);
        IEnumerable<TransportTypeDbModel> getRecordsList();
        TransportTypeDbModel createRecord(TransportTypeDbModel record);
        TransportTypeDbModel updateRecord(TransportTypeDbModel record);
        bool deleteRecordById(int id);
    }
}
