using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.DataContract;
using Guyusoft.IMS.SqlGenerator.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guyusoft.IMS.DatabaseService
{
    public class NavigationMenuService : ModelService<NavigationMenu>
    {
        public NavigationMenuService(ISqlGeneratorFactory factory, ISqlExecuter executer)
            : base(factory, executer)
        {
        }
    }
}
