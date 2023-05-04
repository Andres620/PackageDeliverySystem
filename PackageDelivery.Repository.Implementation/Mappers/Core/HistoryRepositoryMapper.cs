
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class HistoryRepositoryMapper : DbModelMapperBase<HistoryDbModel, historial>
    {
        public override HistoryDbModel DatabaseToDbModelMapper(historial input)
        {
            return new HistoryDbModel()
            {
                Id = (int)input.id,
                description = input.descripcion,
                entryDate = input.fechaIngreso,
                departureDate = input.fechaSalida,
                idPackage = (int)input.idPaquete,
                idWarehouse = (int)input.id
            };
        }

        public override IEnumerable<HistoryDbModel> DatabaseToDbModelMapper(IEnumerable<historial> input)
        {
            IList<HistoryDbModel> list = new List<HistoryDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override historial DbModelToDatabaseMapper(HistoryDbModel input)
        {
            return new historial()
            {
                id = input.Id,
                descripcion = input.description,
                fechaIngreso = input.entryDate,
                fechaSalida = input.departureDate,
                idPaquete = input.idPackage,
                idBodega = input.idWarehouse
            };
        }

        public override IEnumerable<historial> DbModelToDatabaseMapper(IEnumerable<HistoryDbModel> input)
        {
            IList<historial> list = new List<historial>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}