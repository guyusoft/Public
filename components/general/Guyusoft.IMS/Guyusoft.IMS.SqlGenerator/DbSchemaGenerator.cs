using Guyusoft.IMS.SqlGenerator.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Guyusoft.IMS.SqlGenerator
{
    public class DbSchemaGenerator: IDbSchemaGenerator
    {
        public IEnumerable<string> GetAllPublicFields(Type type)
        {
            var publicProperties = new List<string>();

            foreach (var publicField in GetPublicPropertyInfo(type))
            {
                publicProperties.Add(publicField.Name);
            }

            return publicProperties;
        }

        public IDictionary<string, object> GetFieldValuePair(object obj)
        {
            var propertyValuePair = new Dictionary<string, object>();

            foreach (var property in GetPublicPropertyInfo(obj.GetType()))
            {
                propertyValuePair.Add(property.Name, property.GetValue(obj, null));
            }

            return propertyValuePair;
        }

        public string GetKeyName(Type type)
        {
            return "Id";
        }

        public string GetTableName(Type type)
        {
            return type.Name;
        }

        private IEnumerable<PropertyInfo> GetPublicPropertyInfo(Type type)
        {
            return type.GetProperties().AsEnumerable();
        }
    }
}
