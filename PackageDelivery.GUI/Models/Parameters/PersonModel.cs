using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class PersonModel
    {

        [Key]
        public long Id { get; set; }

        [Required]
        [DisplayName("Primer Nombre")]
        public string FirstName { get; set; }

        [DisplayName("Otros Nombres")]
        public string OtherNames { get; set; }

        [Required]
        [DisplayName("Primer Apellido")]
        public string FirstLastname { get; set; }

        [DisplayName("Segundo Apellido")]
        public string SecondLastname { get; set; }

        [Required]
        [DisplayName("Identificación")]
        public string IdentificationNumber { get; set; }

        [Required]
        [DisplayName("Celular")]
        public string Cellphone { get; set; }

        [Required]
        [DisplayName("Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Tipo de Documento")]
        public int IdentificationType { get; set; }

    }
}
