using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class ShipmentStateModel
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
    }
}