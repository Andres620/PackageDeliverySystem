using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class TownModel
    {
		[Key]
		public long Id { get; set; }

		[Required]
		[DisplayName("Nombre del municipio")]
		public string name { get; set; }

		[Required]
		[DisplayName("Id del departamento")]
		public int IdDepartment { get; set; }

    }
}