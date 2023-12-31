using System;

namespace PackageDelivery.Application.Contracts.DTO.CoreDTO
{
    public class HistoryDTO
    {
        public int Id { get; set; }
        public DateTime entryDate { get; set; }
        public DateTime departureDate{ get; set; }
        public string description { get; set; }
        public int idPackage { get; set; }
        public int idWarehouse { get; set; }
    }
}