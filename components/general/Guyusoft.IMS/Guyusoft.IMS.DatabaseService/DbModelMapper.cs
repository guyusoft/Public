using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.Utility;
using System;
using System.Data;
using System.Reflection;

namespace Guyusoft.IMS.DatabaseService
{
    public class DbModelMapper : IDbModelMapper
    {
        public T MapTo<T>(DataSet ds)
        {
            T t = (T)Assembly.GetExecutingAssembly().CreateInstance(typeof(T).FullName);

            foreach (DataRow rowRecord in ds.Tables[0].Rows)
            {
                foreach (var property in Helper.GetTypePublicProperties(t))
                {
                    t.GetType().GetProperty(property).SetValue(t, rowRecord[property], null);
                }
            }

            return t;
        }
    }
}
