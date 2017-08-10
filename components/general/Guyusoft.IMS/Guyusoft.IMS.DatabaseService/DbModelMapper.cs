using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.SqlGenerator.DataContract;
using System.Data;
using System.Reflection;

namespace Guyusoft.IMS.DatabaseService
{
    public class DbModelMapper : IDbModelMapper
    {
        private IDbSchemaGenerator _generator = null;
        public DbModelMapper(IDbSchemaGenerator generator)
        {
            _generator = generator;
        }

        public T MapTo<T>(DataSet ds)
        {
            T t = (T)Assembly.GetAssembly(typeof(T)).CreateInstance(typeof(T).FullName);

            foreach (DataRow rowRecord in ds.Tables[0].Rows)
            {
                foreach (var property in _generator.GetAllPublicFields(typeof(T)))
                {
                    t.GetType().GetProperty(property).SetValue(t, rowRecord[property], null);//TODO
                }
            }

            return t;
        }
    }
}
