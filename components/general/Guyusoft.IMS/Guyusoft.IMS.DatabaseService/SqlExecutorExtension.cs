using System;
using System.Data.SqlClient;
using Guyusoft.IMS.DatabaseService.DataContract;
using System.Data;
using System.Collections.Generic;

namespace Guyusoft.IMS.DatabaseService
{
    public class SqlExecutorExtension : SqlExecutor, ISqlExecuterExtension
    {
        public IDbModelMapper _mapper = null;

        public SqlExecutorExtension(IDbModelMapper mapper):base(mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<T> Execute<T>(string sql)
        {
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sqlAdapter = new SqlDataAdapter(sql, conn);
                var dataset = new DataSet();

                sqlAdapter.Fill(dataset);

                return _mapper.MapToList<T>(dataset);
            }
        }
    }
}
