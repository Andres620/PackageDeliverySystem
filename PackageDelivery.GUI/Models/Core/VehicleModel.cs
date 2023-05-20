using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class VehicleModel
    {
        [Key]
        public int Id { get; set; }

		[Required]
		[DisplayName("Placa")]
		public string plate { get; set; }

		[Required]
		[DisplayName("Id tipo de transporte")]
		public int idTransportType { get; set; }
    }
}