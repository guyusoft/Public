using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.DataContract.Models;
using Microsoft.Practices.Unity;
using System;
using Guyusoft.IMS.DataContract;

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
            _container.RegisterType<IService<NavigationMenu>, NavigationMenuService>();
            //_container.RegisterType<IGenerator, InsertGenerator>(SQLGenerationAction.Insert.ToString());
            //_container.RegisterType<IGenerator, UpdateGenerator>(SQLGenerationAction.Update.ToString());
            //_container.RegisterType<IGenerator, DeleteGenerator>(SQLGenerationAction.Delete.ToString());
        }
    }
}
