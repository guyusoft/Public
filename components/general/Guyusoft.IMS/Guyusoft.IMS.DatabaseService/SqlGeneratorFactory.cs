using System;
using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.Utility.DataContract.SQLGenerator;
using System.Collections.Generic;
using System.Linq;

namespace Guyusoft.IMS.DatabaseService
{
    public class SqlGeneratorFactory : ISqlGeneratorFactory
    {
        private IEnumerable<ISqlGenerator> _generators = null;
        public SqlGeneratorFactory(IEnumerable<ISqlGenerator> generators)
        {
            _generators = generators;
        }
        public ISqlGenerator GetGenerator(SQLGenerationAction action)
        {
            return _generators.Where(x => x.ToString().Contains(SQLGenerationAction.Select.ToString() + "Generator")).FirstOrDefault();
        }
    }
}
