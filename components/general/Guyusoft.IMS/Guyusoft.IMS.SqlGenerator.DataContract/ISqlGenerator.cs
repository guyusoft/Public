namespace Guyusoft.IMS.SqlGenerator.DataContract
{
    public interface ISqlGenerator
    {
        string Get<T>(object obj);
    }
}
