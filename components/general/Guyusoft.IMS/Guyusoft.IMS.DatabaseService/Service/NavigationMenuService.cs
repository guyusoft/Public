using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.DataContract.Models;
using Guyusoft.IMS.Utility.DataContract.SQLGenerator;

namespace Guyusoft.IMS.DatabaseService
{
    public class NavigationMenuService : IService<NavigationMenu>
    {
        private ISqlGeneratorFactory _factory = null;
        private ISqlExecuter _executer = null;
        public NavigationMenuService(ISqlGeneratorFactory factory,ISqlExecuter executer)
        {
            _factory = factory;
            _executer = executer;
        }

        public NavigationMenu Create(NavigationMenu t)
        {
            var generator = _factory.GetGenerator(SQLGenerationAction.Insert);

            var sql = generator.GenerateSql(t);

            return _executer.Insert<NavigationMenu>(sql);
        }

        public bool Delete(NavigationMenu t)
        {
            var generator = _factory.GetGenerator(SQLGenerationAction.Delete);

            var sql = generator.GenerateSql(t);

            return _executer.Execute(sql) > 0;
        }

        public NavigationMenu Get(int id)
        {
            var generator = _factory.GetGenerator(SQLGenerationAction.Select);

            var sql = generator.GenerateSql(new NavigationMenu { Id = id });

            return _executer.Get<NavigationMenu>(sql);
        }

        public NavigationMenu Update(NavigationMenu t)
        {
            //var generator = _factory.GetGenerator(SQLGenerationAction.Update);

            //var sql = generator.GenerateSql(t);

            //return _executer.Execute<NavigationMenu>(sql);
            return null;
        }
    }
}
