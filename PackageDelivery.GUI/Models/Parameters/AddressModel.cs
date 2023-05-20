using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class AddressModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [DisplayName ("Tipo de calle")]
        public string streetType { get; set; }
        [Required]
        [DisplayName("Número")]
        public string number { get; set; }
        [DisplayName("Tipo de inmueble")]
        public string immovableType { get; set; }
        [Required]
        [DisplayName("Barrio")]
        public string neighborhood { get; set; }
        [DisplayName("Observaciones")]
        public string observations { get; set; }
        [Required]
        [DisplayName("Actual")]
        public Boolean actual { get; set; }
        [Required]
        [DisplayName("Id municipio")]
        public int IdTown { get; set; }

    }
}
