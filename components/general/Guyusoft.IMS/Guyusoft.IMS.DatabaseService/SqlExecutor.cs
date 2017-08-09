using System;
using Guyusoft.IMS.DatabaseService.DataContract;

namespace Guyusoft.IMS.DatabaseService
{
    public class SqlExecutor : ISqlExecuter
    {
        public IDbModelMapper _mapper = null;

        public SqlExecutor(IDbModelMapper mapper)
        {
            _mapper = mapper;
        }

        public int Execute(string sql)
        {
            throw new NotImplementedException();
        }

        public T Execute<T>(string sql)
        {
            return _mapper.MapTo<T>(null);
        }
    }
}
