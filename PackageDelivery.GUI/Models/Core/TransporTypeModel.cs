using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class TransportTypeModel
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
    }
}