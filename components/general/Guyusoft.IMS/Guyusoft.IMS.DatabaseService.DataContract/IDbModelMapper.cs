using Guyusoft.IMS.DataContract.Models;
using System.Data;

namespace Guyusoft.IMS.DatabaseService.DataContract
{
    public interface IDbModelMapper
    {
        T MapTo<T>(DataSet ds);
    }
}
