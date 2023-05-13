
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class TownRepositoryMapper : DbModelMapperBase<TownDbModel, municipio>
    {
        public override TownDbModel DatabaseToDbModelMapper(municipio input)
        {
            return new TownDbModel()
            {
                Id = input.id,
                name = input.nombre,
                IdDepartment = (int)input.idDepartamento
            };
        }

        public override IEnumerable<TownDbModel> DatabaseToDbModelMapper(IEnumerable<municipio> input)
        {
            IList<TownDbModel> list = new List<TownDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override municipio DbModelToDatabaseMapper(TownDbModel input)
        {
            return new municipio()
            {
                id = input.Id,
                nombre = input.name,
                idDepartamento = input.IdDepartment
            };
        }

        public override IEnumerable<municipio> DbModelToDatabaseMapper(IEnumerable<TownDbModel> input)
        {
            IList<municipio> list = new List<municipio>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}