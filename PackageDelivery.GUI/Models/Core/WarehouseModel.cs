using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class WarehouseModel
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string address { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int idTown { get; set; }
    }
}