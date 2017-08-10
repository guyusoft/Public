using System.Collections.Generic;

namespace Guyusoft.IMS.SqlGenerator.DataContract
{
    public interface IFilter
    {
        IEnumerable<string> Filter(IEnumerable<string> source);
    }
}
