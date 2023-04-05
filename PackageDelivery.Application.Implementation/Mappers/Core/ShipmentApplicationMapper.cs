using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository_Contracts.DbModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Mappers.Core
{
	internal class ShipmentApplicationMapper : DTOMapperBase<ShipmentDTO, ShipmentDbModel>
	{
		public override ShipmentDTO DbModelToDTOMapper(ShipmentDbModel input)
		{
			return new ShipmentDTO() {
				Id = input.Id,
				shippingDate = input.shippingDate,
				price = input.price,
				idSender = input.idSender,
				idDestinationAddress = input.idDestinationAddress,
				idPackage = input.idPackage,
				idShipmentState	= input.idShipmentState,
				idTransportType = input.idTransportType	
			};
		}

		public override IEnumerable<ShipmentDTO> DbModelToDTOMapper(IEnumerable<ShipmentDbModel> input)
		{
			IList<ShipmentDTO> list = new List<ShipmentDTO>();
			foreach (var item in input)
			{
				list.Add(this.DbModelToDTOMapper(item));
			}
			return list;
		}

		public override ShipmentDbModel DTOToDbModelMapper(ShipmentDTO input)
		{
			return new ShipmentDbModel()
			{
				Id = input.Id,
				shippingDate = input.shippingDate,
				price = input.price,
				idSender = input.idSender,
				idDestinationAddress = input.idDestinationAddress,
				idPackage = input.idPackage,
				idShipmentState = input.idShipmentState,
				idTransportType = input.idTransportType
			};
		}

		public override IEnumerable<ShipmentDbModel> DTOToDbModelMapper(IEnumerable<ShipmentDTO> input)
		{
			IList<ShipmentDbModel> list = new List<ShipmentDbModel>();
			foreach (var item in input)
			{
				list.Add(this.DTOToDbModelMapper(item));
			}
			return list;
		}
	}
}
