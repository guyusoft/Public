using Guyusoft.IMS.DataContract.Exceptions;
using Guyusoft.IMS.Utility.DataContract.SQLGenerator;
using System;
using System.Linq;

namespace Guyusoft.IMS.Utility.SQLGenerator
{
    public class UpdateGenerator : ISqlGenerator
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

            var sql = "UPDATE " + tableName + " SET ";

            foreach (var publicProperty in allPublicProperties)
            {
                if (publicProperty.Equals(keyName))
                {
                    continue;
                }
                var v = Helper.GetValueByPropertyNameFromObject(obj, publicProperty);

                sql = sql + publicProperty + "='" + v.ToString() + "',";
            }

            sql = sql.Substring(0, sql.Length - 1);

            sql = sql + " WHERE " + keyName + " = " + Helper.GetValueByPropertyNameFromObject(obj, keyName);

            return sql;
        }
    }
}
