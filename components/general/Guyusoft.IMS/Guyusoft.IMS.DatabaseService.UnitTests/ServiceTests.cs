using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.DataContract;
using Guyusoft.IMS.SqlGenerator;
using Guyusoft.IMS.SqlGenerator.DataContract;
using NUnit.Framework;
using System.Collections.Generic;

namespace Guyusoft.IMS.DatabaseService.UnitTests
{
    [TestFixture]
    public class ServiceTests
    {
        private ISqlExecuter _executor = null;
        private IDbModelMapper _mapper = null;
        private ISqlGeneratorFactory _factory = null;
        private IDbSchemaGenerator _schemaGenerator = null;
        private IFilter _filter = null;

        [TestFixtureSetUp]
        public void Setup()
        {
            _schemaGenerator = new DbSchemaGenerator();
            _filter = new DbSchemaFilter(_schemaGenerator);
            _mapper = new DbModelMapper(_schemaGenerator);
            _factory = new SqlGeneratorFactory(_schemaGenerator, _filter);
            _executor = new SqlExecutor(_mapper);
        }

        [Test]
        public void NavigationMenuTest()
        {
            var service = new ModelService<NavigationMenu>(_factory, _executor);

            var navigationMenuNew = new NavigationMenu();
            navigationMenuNew.Text = "Sohu";
            navigationMenuNew.Href = "http://www.sohu.com";

            var navigationMenu = service.Create(navigationMenuNew);

            Assert.IsNotNull(navigationMenu);
            Assert.AreEqual("Sohu", navigationMenu.Text);

            navigationMenu.Text = "New Sohu";
            service.Update(navigationMenu);

            Assert.AreEqual("New Sohu", navigationMenu.Text);

            Assert.IsTrue(service.Delete(navigationMenu.Id));

        }
    }
}
