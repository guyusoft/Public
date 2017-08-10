using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.DataContract;
using Microsoft.Practices.Unity;

namespace Guyusoft.IMS.DatabaseService.Bootstrap
{
    public class Component : IComponent
    {
        private IUnityContainer _container = null;

        public Component(IUnityContainer container)
        {
            _container = container;
        }

        public void Register()
        {
            _container.RegisterType<ISqlExecuter, SqlExecutor>();
            _container.RegisterType<IDbModelMapper, DbModelMapper>();
        }
    }
}
