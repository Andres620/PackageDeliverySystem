using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class ShipmentStateModel
    {
        [Key]
        public int Id { get; set; }

		[Required]
		[DisplayName("Estado de envio")]
		public string name { get; set; }
    }
}