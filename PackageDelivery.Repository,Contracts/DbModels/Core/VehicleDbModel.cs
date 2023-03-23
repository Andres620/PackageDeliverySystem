namespace PackageDelivery.Repository_Contracts.DbModels.Core
{
    public class VehicleDbModel
    {
        public int Id { get; set; }
        public string plate { get; set; }
        public int idTransportType { get; set; }
    }
}