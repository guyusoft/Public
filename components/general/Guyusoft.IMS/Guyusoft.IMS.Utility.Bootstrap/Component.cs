using Guyusoft.IMS.Utility.DataContract.SQLGenerator;
using Guyusoft.IMS.Utility.SQLGenerator;
using Microsoft.Practices.Unity;
using System;

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
            _container.RegisterType<IGenerator, SelectGenerator>(SQLGenerationAction.Select.ToString());
            _container.RegisterType<IGenerator, InsertGenerator>(SQLGenerationAction.Insert.ToString());
            _container.RegisterType<IGenerator, UpdateGenerator>(SQLGenerationAction.Update.ToString());
            _container.RegisterType<IGenerator, DeleteGenerator>(SQLGenerationAction.Delete.ToString());
        }
    }
}
