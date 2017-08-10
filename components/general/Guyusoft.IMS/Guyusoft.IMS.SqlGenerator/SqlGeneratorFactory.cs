using Guyusoft.IMS.SqlGenerator.DataContract;

namespace Guyusoft.IMS.SqlGenerator
{
    public class SqlGeneratorFactory : ISqlGeneratorFactory
    {
        private IDbSchemaGenerator _schemaGenerator;
        private IFilter _dbSchemaFilter;

        public SqlGeneratorFactory(IDbSchemaGenerator schemaGenerator, IFilter dbSchemaFilter)
        {
            _schemaGenerator = schemaGenerator;
            _dbSchemaFilter = dbSchemaFilter;
        }

        public ISqlGenerator Create(Generator generatorType)
        {
            if (generatorType == Generator.Select)
            {
                return new SelectGenerator(_schemaGenerator, _dbSchemaFilter);
            }
            if (generatorType == Generator.Delete)
            {
                return new DeleteGenerator(_schemaGenerator);
            }
            if (generatorType == Generator.Insert)
            {
                return new InsertGenerator(_schemaGenerator, _dbSchemaFilter);
            }

            return new UpdateGenerator(_schemaGenerator, _dbSchemaFilter);
        }
    }
}
