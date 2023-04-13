using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class PersonModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Primer nombre")]
        public string firstName { get; set; }
        [DisplayName("Otros nombres")]
        public string otherNames { get; set; }
        [Required]
        [DisplayName("Primer apellido")]
        public string firstLastname { get; set; }
        [DisplayName("Segundo apellido")]
        public string secondLastname { get; set; }
        [Required]
        [DisplayName("Identificación")]
        public string identificationNumber { get; set; }
        [Required]
        [DisplayName("Número móvil")]
        public string cellphone { get; set; }
        [Required]
        [DisplayName("Correo")]
        public string email { get; set; }
        [Required]
        [DisplayName("ID Tipo de documento")]
        public int idDocumentType { get; set; }

    }
}