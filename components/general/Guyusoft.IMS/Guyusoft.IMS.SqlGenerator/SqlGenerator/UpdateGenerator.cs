using Guyusoft.IMS.SqlGenerator.DataContract;
using System;

namespace Guyusoft.IMS.SqlGenerator
{
    public class UpdateGenerator : ISqlGenerator
    {
        private IDbSchemaGenerator _dbSchemaGenerator;
        private IFilter _dbSchemaFilter;
        public UpdateGenerator(DbSchemaGenerator dbSchemaGenerator, IFilter dbSchemaFilter)
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
            var keyName = _dbSchemaGenerator.GetKeyName(type);

            var setString = "";

            foreach (var field in allFields)
            {
                setString = setString + field + "='" + fieldValuePair[field] + "',";
            }

            setString = setString.Substring(0, setString.Length - 1);

            var sql = "UPDATE " + _dbSchemaGenerator.GetTableName(type) + " SET " + setString + " WHERE " + keyName + " = " + fieldValuePair[keyName];

            return sql;
        }
    }
}
