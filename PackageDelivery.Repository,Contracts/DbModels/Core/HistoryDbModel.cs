using System;

namespace PackageDelivery.Repository_Contracts.DbModels.Core
{
    public class HistoryDbModel
    {
        public int Id { get; set; }
        public DateTime entryDate { get; set; }
        public DateTime departureDate{ get; set; }
        public string description { get; set; }
        public int idPackage { get; set; }
        public int idWarehouse { get; set; }
    }
}
