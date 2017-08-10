using Guyusoft.IMS.SqlGenerator.DataContract;
using System;

namespace Guyusoft.IMS.SqlGenerator
{
    public class InsertGenerator : ISqlGenerator
    {
        private IDbSchemaGenerator _dbSchemaGenerator;
        private IFilter _dbSchemaFilter;
        public InsertGenerator(IDbSchemaGenerator dbSchemaGenerator, IFilter dbSchemaFilter)
        {
            _dbSchemaGenerator = dbSchemaGenerator;
            _dbSchemaFilter = dbSchemaFilter;
        }

        public string Get<T>(object obj)
        {
            Type type = typeof(T);

            var allFields = _dbSchemaGenerator.GetAllPublicFields(type);
            allFields = _dbSchemaFilter.Filter(allFields);

            var fieldValuePair = _dbSchemaGenerator.GetFieldValuePair((T)obj);

            var valueString = "";

            foreach (var field in allFields)
            {
                valueString = valueString + "'" + fieldValuePair[field] + "',";
            }

            valueString = valueString.Substring(0, valueString.Length - 1);

            var sql = "INSERT INTO " + _dbSchemaGenerator.GetTableName(type) + " (" + string.Join(",", allFields) + ") VALUES (" + valueString + "); SELECT @@IDENTITY";

            return sql;
        }
    }
}
