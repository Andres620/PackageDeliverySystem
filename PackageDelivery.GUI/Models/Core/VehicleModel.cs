using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class VehicleModel
    {
        [Key]
        public int Id { get; set; }
        public string plate { get; set; }
        public int idTransportType { get; set; }
    }
}