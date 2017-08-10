using Guyusoft.IMS.DataContract;
using Guyusoft.IMS.SqlGenerator.DataContract;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guyusoft.IMS.SqlGenerator.UnitTests
{
    [TestFixture]
    public class DbSchemaFilterTests
    {
        [Test]
        public void FilterTest()
        {
            IDbSchemaGenerator generator = new DbSchemaGenerator();
            var filter = new DbSchemaFilter(generator);

            IEnumerable<string> source = new List<string> { "Id", "Source", "Desc" };

            source = filter.Filter<NavigationMenu>(source);

            Assert.AreEqual(2, source.ToList().Count());
        }
    }
}
