using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository_Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class PackageRepositoryMapper : DbModelMapperBase<PackageDbModel, paquete>
    {
        public override PackageDbModel DatabaseToDbModelMapper(paquete input)
        {
            return new PackageDbModel()
            {
                Id = (int)input.id,
                depth = (float)input.profundidad,
                height = (float)input.altura,
                weight = (float)input.peso,
                width = (float)input.ancho,
                idOffice = (int)input.idOficina
            };
        }

        public override IEnumerable<PackageDbModel> DatabaseToDbModelMapper(IEnumerable<paquete> input)
        {
            IList<PackageDbModel> list = new List<PackageDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override paquete DbModelToDatabaseMapper(PackageDbModel input)
        {
            return new paquete()
            {
                id = input.Id,
                profundidad = input.depth,
                altura = input.height,
                peso = input.weight,
                ancho = input.width,
                idOficina = input.idOffice
            };
        }

        public override IEnumerable<paquete> DbModelToDatabaseMapper(IEnumerable<PackageDbModel> input)
        {
            IList<paquete> list = new List<paquete>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
