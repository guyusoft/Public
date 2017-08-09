using System;
using System.Data.SqlClient;
using Guyusoft.IMS.DatabaseService.DataContract;
using System.Data;

namespace Guyusoft.IMS.DatabaseService
{
    public class SqlExecutor : ISqlExecuter
    {
        public IDbModelMapper _mapper = null;
        private SqlConnection _connection = null;

        public SqlExecutor(IDbModelMapper mapper)
        {
            _connection = new SqlConnection();
            _mapper = mapper;
        }

        public int Execute(string sql)
        {
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sqlCmd = new SqlCommand(sql, _connection);

                return sqlCmd.ExecuteNonQuery();
            }
        }

        public T Execute<T>(string sql)
        {
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sqlAdapter = new SqlDataAdapter(sql, conn);
                var dataset = new DataSet();

                sqlAdapter.Fill(dataset);

                return _mapper.MapTo<T>(dataset);
            }
        }
    }
}
