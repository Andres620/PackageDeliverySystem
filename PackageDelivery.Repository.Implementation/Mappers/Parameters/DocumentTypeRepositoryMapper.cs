using PackageDelivery.Repository.Implementation.DataModel;
namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class DocumentTypeRepositoryMapper: DbModelMapperBase<DocumentTypeDbModel, tipoDocumento>
    {
        public override DatabaseToDbModeltMapper(DocumentTypeDbModel input)
        {
            Id = input.Id;
            name = input.Name;
        }

        public override DbModelToDatabaseMapper(tipoDocumento input)
        {
            id = input.Id;
            Name = input.Name;
        }

        public override IEnumerable<tipoDocumento> DatabaseToDbModeltMapper(IEnumerable<DocumentTypeDbModel> input)
        {
           
        }

        public override IEnumerable<DocumentTypeDbModel> DbModelToDatabaseMapper(IEnumerable<tipoDocumento> input)
        {

        }
    }
}
