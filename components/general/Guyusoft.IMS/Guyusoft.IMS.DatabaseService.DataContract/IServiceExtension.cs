using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guyusoft.IMS.DatabaseService.DataContract
{
    public interface IServiceExtension<T>: IService<T>
    {
        IEnumerable<T> GetAll();
    }
}
