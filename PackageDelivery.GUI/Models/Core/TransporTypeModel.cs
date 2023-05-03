using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class TransportTypeModel
    {
        [Key]
        public int Id { get; set; }

		[Required]
		[DisplayName("Tipo de transporte")]
		public string name { get; set; }
    }
}