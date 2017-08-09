using NUnit.Framework;
using System.Linq;

namespace Guyusoft.IMS.Utility.UnitTests
{
    [TestFixture]
    public class HelperTests
    {
        [Test]
        public void GetTypePublicPropertiesTest()
        {

            var allPublicProperties = Helper.GetTypePublicProperties(typeof(TestClass)).ToList();

            Assert.AreEqual(2, allPublicProperties.Count());

            Assert.AreEqual("Id", allPublicProperties[0]);
            Assert.AreEqual("Description", allPublicProperties[1]);
        }

        [Test]
        public void GetObjectPublicPropertiesTest()
        {
            var testClass = new TestClass();

            var allPublicProperties = Helper.GetTypePublicProperties(testClass).ToList();

            Assert.AreEqual(2, allPublicProperties.Count());

            Assert.AreEqual("Id", allPublicProperties[0]);
            Assert.AreEqual("Description", allPublicProperties[1]);
        }

        [Test]
        public void GetPropertyValueFromObjectTest()
        {
            var testClass = new TestClass();
            testClass.Id = 2;

            var v = Helper.GetValueByPropertyNameFromObject(testClass, "Id");

            Assert.AreEqual(2, v);
        }
    }

    public class TestClass
    {
        public int Id { get; set; }

        public string Description { get; set; }

        protected string Name { get; set; }

        private string Year { get; set; }
    }
}
