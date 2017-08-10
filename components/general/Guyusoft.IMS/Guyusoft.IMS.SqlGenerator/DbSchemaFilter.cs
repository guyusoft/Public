using Guyusoft.IMS.SqlGenerator.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Guyusoft.IMS.SqlGenerator
{
    public class DbSchemaFilter : IFilter
    {
        private IDbSchemaGenerator _generator = null;
        public DbSchemaFilter(IDbSchemaGenerator generator)
        {
            _generator = generator;
        }
        public IEnumerable<string> Filter<T>(IEnumerable<string> source)
        {
            var keyName = _generator.GetKeyName(typeof(T));

            return source.Where(x => !x.Equals(keyName));
        }
    }
}
