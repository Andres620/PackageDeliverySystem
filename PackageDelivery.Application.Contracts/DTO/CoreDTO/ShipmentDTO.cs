using System;

namespace PackageDelivery.Application.Contracts.DTO.CoreDTO
{
    public class ShipmentDTO
    {
        public int Id { get; set; }
        public DateTime shippingDate { get; set; }
        public int price { get; set; }
        public int idSender { get; set; }
        public int idDestinationAddress { get; set; }
        public int idPackage { get; set; }
        public int idShipmentState { get; set; }
        public int idTransportType { get; set; }
    }
}