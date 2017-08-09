using Guyusoft.IMS.Utility.DataContract.SQLGenerator;
using System;

namespace Guyusoft.IMS.Utility.SQLGenerator
{
    public class DeleteGenerator : IGenerator
    {
        public string GenerateSql(object obj)
        {
            var keyName = "Id";
            var keyValue = Helper.GetValueByPropertyNameFromObject(obj, keyName);

            return "DELETE FROM "+ obj.GetType().Name + " WHERE " + keyName + " = " + keyValue;
        }
    }
}
