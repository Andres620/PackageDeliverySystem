using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class DepartmentModel
    {
        [Key]
        public long Id { get; set; }

		[Required]
		[DisplayName("Nombre del departamento")]
		public string name { get; set; }
    }
}