﻿using Guyusoft.IMS.DataContract.Exceptions;
using Guyusoft.IMS.Utility.DataContract.SQLGenerator;
using System;
using System.Linq;

namespace Guyusoft.IMS.Utility.SQLGenerator
{
    public class InsertGenerator : IGenerator
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
            sql = sql.Replace(keyName + ",", "");

            foreach (var publicProperty in allPublicProperties)
            {
                if (publicProperty.Equals(keyName))
                {
                    continue;
                }
                var  v = Helper.GetValueByPropertyNameFromObject(obj, publicProperty);

                sql = sql + "'" + v.ToString() + "'";
            }

            sql = sql + ")";

            return sql;
        }
    }
}