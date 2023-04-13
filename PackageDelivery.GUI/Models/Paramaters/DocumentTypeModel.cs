using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class DocumentTypeModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        [DisplayName("Tipo de Documento")]
        public string name { get; set; }
    }
}