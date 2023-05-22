using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
	public class HistoryModel
	{
		[Key]
		public int Id { get; set; }

		[Required]
        [DisplayName("Fecha de ingreso")]
		public DateTime entryDate { get; set; }

		[Required]
        [DisplayName("Fecha de salida")]
		public DateTime departureDate { get; set; }

		[DisplayName("Descripción")]
		public string description { get; set; }

		[Required]
		[DisplayName("Id de paquete")]
		public int idPackage { get; set; }

		[Required]
		[DisplayName("Id de bodega")]
		public int idWarehouse { get; set; }
    }
}