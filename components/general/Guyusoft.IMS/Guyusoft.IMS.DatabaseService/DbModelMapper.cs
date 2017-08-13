using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.SqlGenerator.DataContract;
using System.Collections.Generic;
using System.Data;

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
            T t = _generator.CreateInstance<T>();

            foreach (DataRow rowRecord in ds.Tables[0].Rows)
            {
                foreach (var property in _generator.GetAllPublicFields(typeof(T)))
                {
                    _generator.SetPropertyValue<T>(t, property, rowRecord[property]);
                }
                break;
            }

            return t;
        }


        IEnumerable<T> IDbModelMapper.MapToList<T>(DataSet ds)
        {
            var results = new List<T>();

            foreach (DataRow rowRecord in ds.Tables[0].Rows)
            {
                T t = _generator.CreateInstance<T>();

                foreach (var property in _generator.GetAllPublicFields(typeof(T)))
                {
                    _generator.SetPropertyValue<T>(t, property, rowRecord[property]);
                }

                results.Add(t);
            }

            return results;
        }
    }
}
