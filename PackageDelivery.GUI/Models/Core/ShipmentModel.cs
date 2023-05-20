using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class ShipmentModel
    {
        [Key]
        public int Id { get; set; }

		[Required]
		[DisplayName("Fecha de envio")]
		public DateTime shippingDate { get; set; }

		[Required]
		[DisplayName("Precio")]
		public int price { get; set; }

		[Required]
		[DisplayName("Id remitente")]
		public int idSender { get; set; }

		[Required]
		[DisplayName("Id dirección destino")]
		public int idDestinationAddress { get; set; }

		[Required]
		[DisplayName("Id paquete")]
		public int idPackage { get; set; }

		[Required]
		[DisplayName("Id estado de envio")]
		public int idShipmentState { get; set; }

		[Required]
		[DisplayName("Id tipo de transporte")]
		public int idTransportType { get; set; }
    }
}