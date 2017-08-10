using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.SqlGenerator.DataContract;

namespace Guyusoft.IMS.DatabaseService
{
    public class ModelService<T> : IService<T>
    {
        private ISqlGeneratorFactory _factory = null;
        private ISqlExecuter _executer = null;

        public ModelService(ISqlGeneratorFactory factory,ISqlExecuter executer)
        {
            _factory = factory;
            _executer = executer;
        }

        public T Create(T t)
        {
            var generator = _factory.Create(Generator.Insert);

            var sql = generator.Get<T>(t);

            var id = _executer.Execute(sql);

            return Get(id);
        }

        public bool Delete(int id)
        {
            var generator = _factory.Create(Generator.Delete);

            var sql = generator.Get<T>(id);

            return _executer.Execute(sql) > 0;
        }

        public T Get(int id)
        {
            var generator = _factory.Create(Generator.Select);

            var sql = generator.Get<T>(id);

            return _executer.Execute<T>(sql);
        }

        public T Update(T t)
        {
            var generator = _factory.Create(Generator.Update);

            var sql = generator.Get<T>(t);

            _executer.Execute(sql);

            return t;
        }
    }
}
