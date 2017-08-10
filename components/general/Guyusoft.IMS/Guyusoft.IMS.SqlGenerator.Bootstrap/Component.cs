using Guyusoft.IMS.DataContract;
using Guyusoft.IMS.SqlGenerator.DataContract;
using Microsoft.Practices.Unity;

namespace Guyusoft.IMS.SqlGenerator.Bootstrap
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
            RegisterSchema();
        }

        private void RegisterSchema()
        {
            _container.RegisterType<IDbSchemaGenerator, DbSchemaGenerator>();
            _container.RegisterType<IFilter, DbSchemaFilter>();
        }

        private void RegisterFactory()
        {
            _container.RegisterType<ISqlGeneratorFactory, SqlGeneratorFactory>();
        }
    }
}
