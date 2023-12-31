﻿using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Core
{
    internal class VehicleApplicationMapper : DTOMapperBase<VehicleDTO, VehicleDbModel>
    {
        public override VehicleDTO DbModelToDTOMapper(VehicleDbModel input)
        {
            return new VehicleDTO()
            {
                Id = input.Id,
                plate = input.plate,
                idTransportType = input.idTransportType
            };
        }

        public override IEnumerable<VehicleDTO> DbModelToDTOMapper(IEnumerable<VehicleDbModel> input)
        {
            IList<VehicleDTO> list = new List<VehicleDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override VehicleDbModel DTOToDbModelMapper(VehicleDTO input)
        {
            return new VehicleDbModel()
            {
                Id = input.Id,
                plate = input.plate,
                idTransportType = input.idTransportType
            };
        }

        public override IEnumerable<VehicleDbModel> DTOToDbModelMapper(IEnumerable<VehicleDTO> input)
        {
            IList<VehicleDbModel> list = new List<VehicleDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}