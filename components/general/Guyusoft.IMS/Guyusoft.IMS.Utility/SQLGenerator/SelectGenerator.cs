using Guyusoft.IMS.DataContract.Exceptions;
using Guyusoft.IMS.Utility.DataContract.SQLGenerator;
using System.Linq;

namespace Guyusoft.IMS.Utility.SQLGenerator
{
    public class SelectGenerator : ISqlGenerator
    {
        public string GenerateSql(object obj)
        {
            var allPublicProperties = Helper.GetTypePublicProperties(obj);

            if (allPublicProperties.Count() == 0)
            {
                throw new NoPublicPropertyException(obj.GetType().FullName);
            }

            var columnDefinition = string.Join(",", allPublicProperties);

            var keyName = "Id";

            var keyValue = Helper.GetValueByPropertyNameFromObject(obj, keyName);

            return "SELECT " + columnDefinition + " FROM " + obj.GetType().Name + " WHERE " + keyName + " = " + keyValue;
        }
    }
}
