namespace Guyusoft.IMS.DatabaseService.DataContract
{
    public interface IService<T>
    {
        T Create(T t);
        T Update(T t);
        bool Delete(int id);
        T Get(int id);
    }
}
