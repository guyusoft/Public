using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.SqlGenerator.DataContract;

namespace Guyusoft.IMS.DatabaseService
{
    public class ModelServiceExtension<T> : ModelService<T>, IServiceExtension<T>
    {
        private ISqlGeneratorFactory _factory = null;
        private ISqlExecuter _executer = null;
        private ISqlExecuterExtension _executerExtension = null;

        public ModelServiceExtension(ISqlGeneratorFactory factory, ISqlExecuter executer, ISqlExecuterExtension executerExtension)
            : base(factory, executer)
        {
            _factory = factory;
            _executer = executer;
            _executerExtension = executerExtension;
        }

        public System.Collections.Generic.IEnumerable<T> GetAll()
        {
            var generator = _factory.Create(Generator.GetAll);

            var sql = generator.Get<T>(null);

            return _executerExtension.Execute<T>(sql);
        }
    }
}
