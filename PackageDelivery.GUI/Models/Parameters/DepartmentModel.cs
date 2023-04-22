using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class DepartmentModel
    {
        [Key]
        public long Id { get; set; }
        public string name { get; set; }
    }
}