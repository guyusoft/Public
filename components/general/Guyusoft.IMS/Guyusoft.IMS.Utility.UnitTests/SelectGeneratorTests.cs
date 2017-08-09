using Guyusoft.IMS.Utility.DataContract.SQLGenerator;
using Guyusoft.IMS.Utility.SQLGenerator;
using NUnit.Framework;

namespace Guyusoft.IMS.Utility.UnitTests
{
    [TestFixture]
    public class SelectGeneratorTests
    {
        [Test]
        public void SelectGeneratorTest()
        {
            var testClass = new TestClass();
            testClass.Id = 2;

            ISqlGenerator generator = new SelectGenerator();

            var sql = generator.GenerateSql(testClass);

            Assert.AreEqual("SELECT Id,Description FROM TestClass WHERE Id = 2", sql);
        }
    }
}
