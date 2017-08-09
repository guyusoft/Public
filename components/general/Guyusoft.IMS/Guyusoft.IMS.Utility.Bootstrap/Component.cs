using Guyusoft.IMS.DataContract;
using Guyusoft.IMS.Utility.DataContract.SQLGenerator;
using Guyusoft.IMS.Utility.SQLGenerator;
using Microsoft.Practices.Unity;

namespace Guyusoft.IMS.Utility.Bootstrap
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
            _container.RegisterType<ISqlGenerator, SelectGenerator>(SQLGenerationAction.Select.ToString());
            _container.RegisterType<ISqlGenerator, InsertGenerator>(SQLGenerationAction.Insert.ToString());
            _container.RegisterType<ISqlGenerator, UpdateGenerator>(SQLGenerationAction.Update.ToString());
            _container.RegisterType<ISqlGenerator, DeleteGenerator>(SQLGenerationAction.Delete.ToString());
        }
    }
}
