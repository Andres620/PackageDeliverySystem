using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class WarehouseModel
    {
        [Key]
        public int Id { get; set; }

		[Required]
		[DisplayName("Nombre de bodega")]
		public string name { get; set; }

		[Required]
		[DisplayName("Código de bodega")]
		public string code { get; set; }

		[Required]
		[DisplayName("Direccíon de bodega")]
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