using Guyusoft.IMS.SqlGenerator.DataContract;
using System;

namespace Guyusoft.IMS.SqlGenerator
{
    public class DeleteGenerator : ISqlGenerator
    {
        private IDbSchemaGenerator _dbSchemaGenerator;
        public DeleteGenerator(IDbSchemaGenerator dbSchemaGenerator)
        {
            _dbSchemaGenerator = dbSchemaGenerator;
        }

        public string Get<T>(object obj)
        {
            Type type = typeof(T);

            var tabelName = _dbSchemaGenerator.GetTableName(type);
            var keyName = _dbSchemaGenerator.GetKeyName(type);

            return "DELETE FROM " + tabelName + " WHERE " + keyName + " = " + obj + ";SELECT @@ROWCOUNT";
        }
    }
}
