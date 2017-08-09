using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.DataContract.Models;
using Guyusoft.IMS.Utility.DataContract.SQLGenerator;
using Guyusoft.IMS.Utility.SQLGenerator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guyusoft.IMS.DatabaseService.UnitTests
{
    [TestFixture]
    public class ServiceTests
    {
        private ISqlGeneratorFactory _factory = null;
        private ISqlExecuter _executor = null;
        private IDbModelMapper _mapper = null;
        private List<ISqlGenerator> _generators = null;

        [TestFixtureSetUp]
        public void Setup()
        {
            _generators = new List<ISqlGenerator>();
            _generators.Add(new SelectGenerator());
            _generators.Add(new InsertGenerator());
            _generators.Add(new DeleteGenerator());
            _generators.Add(new UpdateGenerator());

            _factory = new SqlGeneratorFactory(_generators);
            _mapper = new DbModelMapper();
            _executor = new SqlExecutor(_mapper);
        }

        [Test]
        public void NavigationMenuTest()
        {
            var service = new NavigationMenuService(_factory, _executor);

            var navigationMenuNew = new NavigationMenu();
            navigationMenuNew.Text = "Sohu";
            navigationMenuNew.Href = "http://www.sohu.com";

            var navigationMenu = service.Create(navigationMenuNew);

            Assert.IsNotNull(navigationMenu);
        }
    }
}
