using System;

namespace PackageDelivery.Repository.Contracts.DbModels.Parameters
{
    public class AddressDbModel
    {
        public long Id { get; set; }
        public string streetType { get; set; }
        public string number { get; set; }
        public string immovableType { get; set; }
        public string neighborhood { get; set; }
        public string observations { get; set; }
        public Boolean actual { get; set; }
        public int IdPerson { get; set; }
        public int IdTown { get; set; }

    }
}