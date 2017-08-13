using Guyusoft.IMS.SqlGenerator.DataContract;
using System;

namespace Guyusoft.IMS.SqlGenerator
{
    public class GetAllGenerator : ISqlGenerator
    {
        private IDbSchemaGenerator _dbSchemaGenerator;
        public GetAllGenerator(IDbSchemaGenerator dbSchemaGenerator)
        {
            _dbSchemaGenerator = dbSchemaGenerator;
        }

        public string Get<T>(object obj)
        {
            Type type = typeof(T);

            var allFields = _dbSchemaGenerator.GetAllPublicFields(type);

            var sql = "SELECT " + string.Join(",", allFields) + " FROM " + _dbSchemaGenerator.GetTableName(type);

            return sql;
        }
    }
}
