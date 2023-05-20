using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class PackageModel
    {
        [Key]
        public int Id { get; set; }

		[DisplayName("Peso")]
		public float weight { get; set; }

		[DisplayName("Altura")]
		public float height { get; set; }

		[DisplayName("Profundidad")]
		public float depth { get; set; }

		[DisplayName("Ancho")]
		public float width { get; set; }

		[Required]
		[DisplayName("Id oficina")]
		public int idOffice { get; set; }

    }
}