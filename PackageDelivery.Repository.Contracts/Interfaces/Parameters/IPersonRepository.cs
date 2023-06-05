using PackageDelivery.Repository.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces.Parameters
{
    public interface IPersonRepository
    {
        PersonDbModel getRecordById(int id);
        IEnumerable<PersonDbModel> getRecordsList();
        PersonDbModel createRecord(PersonDbModel record);
        PersonDbModel updateRecord(PersonDbModel record);
        bool deleteRecordById(int id);
    }
}
