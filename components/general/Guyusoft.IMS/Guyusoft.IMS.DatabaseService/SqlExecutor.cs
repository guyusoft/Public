using System;
using System.Data.SqlClient;
using Guyusoft.IMS.DatabaseService.DataContract;
using System.Data;

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
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sqlCmd = new SqlCommand(sql, conn);

                return sqlCmd.ExecuteNonQuery();
            }
        }

        public T Get<T>(string sql)
        {
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sqlAdapter = new SqlDataAdapter(sql, conn);
                var dataset = new DataSet();

                sqlAdapter.Fill(dataset);

                return _mapper.MapTo<T>(dataset);
            }
        }


        public T Insert<T>(string insertSql, string selectSql)
        {
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sqlCmd = new SqlCommand(insertSql, conn);
                conn.Open();
                int id = int.Parse(sqlCmd.ExecuteScalar().ToString());

                if (id > 0)
                {
                    var sqlAdapter = new SqlDataAdapter(selectSql, conn);
                    var dataset = new DataSet();

                    sqlAdapter.Fill(dataset);

                    return _mapper.MapTo<T>(dataset);
                }

                return default(T);
            }
        }
    }
}
