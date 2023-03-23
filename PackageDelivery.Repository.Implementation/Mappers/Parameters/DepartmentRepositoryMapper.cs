using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class DepartmentRepositoryMapper : DbModelMapperBase<DepartmentDbModel, departamento>
    {
        public override DepartmentDbModel DatabaseToDbModelMapper(departamento input)
        {
            return new DepartmentDbModel()
            {
                Id = input.id,
                name = input.nombre
               
            };
        }

        public override IEnumerable<DepartmentDbModel> DatabaseToDbModelMapper(IEnumerable<departamento> input)
        {
            IList<DepartmentDbModel> list = new List<DepartmentDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override departamento DbModelToDatabaseMapper(DepartmentDbModel input)
        {
            return new departamento()
            {
                id = input.Id,
                nombre = input.name
            };
        }

        public override IEnumerable<departamento> DbModelToDatabaseMapper(IEnumerable<DepartmentDbModel> input)
        {
            IList<departamento> list = new List<departamento>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
