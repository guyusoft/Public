using Guyusoft.IMS.DataContract;
using System.Data;

namespace Guyusoft.IMS.DatabaseService.DataContract
{
    public interface IDbModelMapper
    {
        T MapTo<T>(DataSet ds);
    }
}
