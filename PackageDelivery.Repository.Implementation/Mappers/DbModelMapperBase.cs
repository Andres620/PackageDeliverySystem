using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers
{
    public abstract class DbModelMapperBase<DbModelType, DatabaseType>
    {
        public abstract DatabaseType DatabaseToDbModeltMapper(DbModelType input);
        public abstract DbModelType DbModelToDatabaseMapper(DatabaseType input);
        public abstract IEnumerable <DatabaseType> DatabaseToDbModeltMapper(IEnumerable <DbModelType> input);
        public abstract IEnumerable <DbModelType> DbModelToDatabaseMapper(IEnumerable <DatabaseType> input);
    }
}
