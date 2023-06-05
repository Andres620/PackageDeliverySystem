using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class PersonModel
    {

        [Key]
        public long Id { get; set; }

        [Required]
        [DisplayName("Primer nombre")]
        public string FirstName { get; set; }

        [DisplayName("Otros nombres")]
        public string OtherNames { get; set; }

        [Required]
        [DisplayName("Primer apellido")]
        public string FirstLastname { get; set; }

        [DisplayName("Segundo apellido")]
        public string SecondLastname { get; set; }

        [Required]
        [DisplayName("Identificación")]
        public string IdentificationNumber { get; set; }

        [Required]
        [DisplayName("Celular")]
        public string Cellphone { get; set; }

        [Required]
        [DisplayName("Correo electrónico")]
        public string Email { get; set; }

		[Required]
		[DisplayName("Id dirección")]
		public int Address { get; set; }

        [Required]
        [DisplayName("Id tipo de documento")]
        public int IdDocumentType { get; set; }

    }
}
