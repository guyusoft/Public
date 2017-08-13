using Guyusoft.IMS.DataContract;
using System.Collections.Generic;
using System.Data;

namespace Guyusoft.IMS.DatabaseService.DataContract
{
    public interface IDbModelMapper
    {
        T MapTo<T>(DataSet ds);

        IEnumerable<T> MapToList<T>(DataSet ds);
    }
}
