namespace Guyusoft.IMS.DatabaseService.DataContract
{
    public interface ISqlExecuter
    {
        int Execute(string sql);

        T Get<T>(string sql);

        T Insert<T>(string insertSql, string selectSql);
    }
}
