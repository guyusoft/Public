using Guyusoft.IMS.SqlGenerator.DataContract;
using System.Collections.Generic;
using System.Linq;

namespace Guyusoft.IMS.SqlGenerator
{
    public class DbSchemaFilter : IFilter
    {
        public IEnumerable<string> Filter(IEnumerable<string> source)
        {
            return source.SkipWhile(x => x.Equals("Id"));
        }
    }
}
