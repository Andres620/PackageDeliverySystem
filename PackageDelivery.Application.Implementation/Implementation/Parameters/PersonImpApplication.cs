using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using System;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class PersonImpApplication : IPersonApplication
    {
        public PersonDTO createRecord(PersonDTO record)
        {
            throw new NotImplementedException();
        }

        public bool deleteRecordById(int id)
        {
            throw new NotImplementedException();
        }

        public PersonDTO getRecordById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonDTO> getRecordsList(string filter)
        {
            throw new NotImplementedException();
        }

        public PersonDTO updateRecord(PersonDTO record)
        {
            throw new NotImplementedException();
        }
    }
}
