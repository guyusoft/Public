using Guyusoft.IMS.DatabaseService.DataContract;
using NUnit.Framework;
using System.Collections.Generic;

namespace Guyusoft.IMS.DatabaseService.UnitTests
{
    [TestFixture]
    public class ServiceTests
    {
        private ISqlExecuter _executor = null;
        private IDbModelMapper _mapper = null;

        [TestFixtureSetUp]
        public void Setup()
        {
            _executor = new SqlExecutor(_mapper);
        }

        [Test]
        public void NavigationMenuTest()
        {
            //var service = new NavigationMenuService(_factory, _executor);

            //var navigationMenuNew = new NavigationMenu();
            //navigationMenuNew.Text = "Sohu";
            //navigationMenuNew.Href = "http://www.sohu.com";

            //var navigationMenu = service.Create(navigationMenuNew);

            //Assert.IsNotNull(navigationMenu);
        }
    }
}
