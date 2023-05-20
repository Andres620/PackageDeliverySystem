using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class DocumentTypeModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Tipo de documento")]
        public string Name { get; set; }
    }
}
