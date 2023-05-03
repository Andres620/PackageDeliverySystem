using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class OfficeModel
    {
        [Key]
        public int Id { get; set; }

		[Required]
		[DisplayName("Nombre de oficina")]
		public string name { get; set; }

		[Required]
		[DisplayName("Código de oficina")]
		public string code { get; set; }

		[Required]
		[DisplayName("Celular")]
		public string cellphone { get; set; }

		[Required]
		[DisplayName("Dirección")]
		public string address { get; set; }

		[DisplayName("Latitud")]
		public string latitude { get; set; }

		[DisplayName("Longitud")]
		public string longitude { get; set; }

		[Required]
		[DisplayName("Municipio")]
		public int idTown { get; set; }

    }
}