using System.Collections.Generic;
namespace Guyusoft.IMS.DatabaseService.DataContract
{
    public interface ISqlExecuterExtension: ISqlExecuter
    {
        IEnumerable<T> Execute<T>(string sql);
    }
}
