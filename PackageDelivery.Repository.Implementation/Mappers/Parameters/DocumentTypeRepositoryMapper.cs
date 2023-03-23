using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class DocumentTypeRepositoryMapper: DbModelMapperBase<DocumentTypeDbModel, tipoDocumento>
    {
        public override DocumentTypeDbModel DatabaseToDbModelMapper(tipoDocumento input)
        {
            return new DocumentTypeDbModel()
            {
                Id = input.id,
                name = input.nombre
            };
        }

        public override IEnumerable<DocumentTypeDbModel> DatabaseToDbModelMapper(IEnumerable<tipoDocumento> input)
        {
            IList<DocumentTypeDbModel> list = new List<DocumentTypeDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override tipoDocumento DbModelToDatabaseMapper(DocumentTypeDbModel input)
        {
            return new tipoDocumento()
            {
                id = input.Id,
                nombre = input.name
            };
        }

        public override IEnumerable<tipoDocumento> DbModelToDatabaseMapper(IEnumerable<DocumentTypeDbModel> input)
        {
            IList<tipoDocumento> list = new List<tipoDocumento>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
