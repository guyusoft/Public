using System;
using System.Collections.Generic;

namespace Guyusoft.IMS.Utility
{
    public class Helper
    {
        #region Get public properties based on object instance or type
        public static IEnumerable<string> GetTypePublicProperties(Type type)
        {
            var publicProperties = new List<string>();

            foreach (var publicField in type.GetProperties())
            {
                publicProperties.Add(publicField.Name);
            }

            return publicProperties;
        }

        public static IEnumerable<string> GetTypePublicProperties(object obj)
        {
            var publicProperties = new List<string>();

            foreach (var publicField in obj.GetType().GetProperties())
            {
                publicProperties.Add(publicField.Name);
            }

            return publicProperties;
        }
        #endregion

        #region Get property value from object based on name
        public static object GetValueByPropertyNameFromObject(object obj,string propertyName)
        {
            var property = obj.GetType().GetProperty(propertyName);

            if (property != null)
            {
                return property.GetValue(obj, null);
            }

            return null;
        }
        #endregion
    }
}
