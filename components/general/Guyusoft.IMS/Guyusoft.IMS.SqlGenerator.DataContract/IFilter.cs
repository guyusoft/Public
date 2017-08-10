using System.Collections.Generic;

namespace Guyusoft.IMS.SqlGenerator.DataContract
{
    public interface IFilter
    {
        IEnumerable<string> Filter<T>(IEnumerable<string> source);
    }
}
