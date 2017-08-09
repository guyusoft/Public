using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.DataContract.Models;
using Guyusoft.IMS.Utility.DataContract.SQLGenerator;

namespace Guyusoft.IMS.DatabaseService
{
    public class BaseModelService : IService<BaseModel>
    {
        private ISqlGeneratorFactory _factory = null;
        private ISqlExecuter _executer = null;
        public BaseModelService(ISqlGeneratorFactory factory,ISqlExecuter executer)
        {
            _factory = factory;
            _executer = executer;
        }

        public BaseModel Create(BaseModel t)
        {
            var generator = _factory.GetGenerator(SQLGenerationAction.Insert);

            var sql = generator.GenerateSql(t);

            return _executer.Execute<BaseModel>(sql);
        }

        public bool Delete(BaseModel t)
        {
            var generator = _factory.GetGenerator(SQLGenerationAction.Delete);

            var sql = generator.GenerateSql(t);

            return _executer.Execute(sql) > 0;
        }

        public BaseModel Get(int id)
        {
            var generator = _factory.GetGenerator(SQLGenerationAction.Select);

            var sql = generator.GenerateSql(new BaseModel { Id = id });

            return _executer.Execute<BaseModel>(sql);
        }

        public BaseModel Update(BaseModel t)
        {
            var generator = _factory.GetGenerator(SQLGenerationAction.Update);

            var sql = generator.GenerateSql(t);

            return _executer.Execute<BaseModel>(sql);
        }
    }
}
