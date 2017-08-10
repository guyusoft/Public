using Guyusoft.IMS.SqlGenerator.DataContract;

namespace Guyusoft.IMS.SqlGenerator
{
    public class SqlGeneratorFactory : ISqlGeneratorFactory
    {
        public ISqlGenerator Create(Generator generatorType)
        {
            var dbSchemaGenerator = new DbSchemaGenerator();
            var dbFilter = new DbSchemaFilter();

            if (generatorType == Generator.Select)
            {
                return new SelectGenerator(dbSchemaGenerator, dbFilter);
            }
            if (generatorType == Generator.Delete)
            {
                return new DeleteGenerator(dbSchemaGenerator);
            }
            if (generatorType == Generator.Insert)
            {
                return new InsertGenerator(dbSchemaGenerator, dbFilter);
            }

            return new UpdateGenerator(dbSchemaGenerator, dbFilter);
        }
    }
}
