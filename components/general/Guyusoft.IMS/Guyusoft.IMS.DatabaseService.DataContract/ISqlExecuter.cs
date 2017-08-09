namespace Guyusoft.IMS.DatabaseService.DataContract
{
    public interface ISqlExecuter
    {
        int Execute(string sql);

        T Execute<T>(string sql);
    }
}
