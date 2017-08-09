using Guyusoft.IMS.DataContract.Exceptions;
using Guyusoft.IMS.Utility.DataContract.SQLGenerator;
using System;
using System.Linq;

namespace Guyusoft.IMS.Utility.SQLGenerator
{
    public class InsertGenerator : ISqlGenerator
    {
        public string GenerateSql(object obj)
        {
            var allPublicProperties = Helper.GetTypePublicProperties(obj);

            if (allPublicProperties.Count() == 0)
            {
                throw new NoPublicPropertyException(obj.GetType().FullName);
            }

            var tableName = obj.GetType().Name;
            var keyName = "Id";

            var sql = "INSERT INTO " + tableName + " (" + string.Join(",", allPublicProperties) + ") VALUES (";
            sql = sql.Replace(keyName + ",", "").Replace("," + keyName, "");
            if (sql.EndsWith(","))
            {
                sql = sql.Substring(0, sql.Length - 1);
            }

            foreach (var publicProperty in allPublicProperties)
            {
                if (publicProperty.Equals(keyName))
                {
                    continue;
                }
                var  v = Helper.GetValueByPropertyNameFromObject(obj, publicProperty);

                sql = sql + "'" + v.ToString() + "',";
            }

            sql = sql.Substring(0, sql.Length - 1);

            sql = sql + "); SELECT @@IDENTITY";

            return sql;
        }
    }
}
