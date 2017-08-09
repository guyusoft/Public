namespace Guyusoft.IMS.DatabaseService.DataContract
{
    public interface IService<T>
    {
        T Create(T t);
        T Update(T t);
        bool Delete(T t);
        T Get(int id);
    }
}
