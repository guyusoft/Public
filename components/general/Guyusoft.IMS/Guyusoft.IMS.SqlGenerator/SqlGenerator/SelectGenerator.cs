using Guyusoft.IMS.SqlGenerator.DataContract;
using System;

namespace Guyusoft.IMS.SqlGenerator
{
    public class SelectGenerator : ISqlGenerator
    {
        private IDbSchemaGenerator _dbSchemaGenerator;
        private IFilter _dbSchemaFilter;
        public SelectGenerator(IDbSchemaGenerator dbSchemaGenerator, IFilter dbSchemaFilter)
        {
            _dbSchemaGenerator = dbSchemaGenerator;
            _dbSchemaFilter = dbSchemaFilter;
        }

        public string Get<T>(object obj)
        {
            Type type = typeof(T);

            var allFields = _dbSchemaGenerator.GetAllPublicFields(type);

            var sql = "SELECT " + string.Join(",", allFields) + " FROM " + _dbSchemaGenerator.GetTableName(type) + " WHERE " + _dbSchemaGenerator.GetKeyName(type) + " = " + obj;

            return sql;
        }
    }
}
