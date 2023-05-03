using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class PackageModel
    {
        [Key]
        public int Id { get; set; }

		[Required]
		[DisplayName("Peso")]
		public float weight { get; set; }

		[Required]
		[DisplayName("Altura")]
		public float height { get; set; }

		[Required]
		[DisplayName("Profundidad")]
		public float depth { get; set; }

		[Required]
		[DisplayName("Ancho")]
		public float width { get; set; }

		[Required]
		[DisplayName("Oficina")]
		public int idOffice { get; set; }

    }
}