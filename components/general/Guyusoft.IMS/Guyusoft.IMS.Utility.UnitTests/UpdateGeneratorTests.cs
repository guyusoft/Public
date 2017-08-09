using Guyusoft.IMS.Utility.DataContract.SQLGenerator;
using Guyusoft.IMS.Utility.SQLGenerator;
using NUnit.Framework;

namespace Guyusoft.IMS.Utility.UnitTests
{
    [TestFixture]
    public class UpdateGeneratorTests
    {
        [Test]
        public void UpdateGeneratorTest()
        {
            var testClass = new TestClass();
            testClass.Description = "Test";
            testClass.Id = 2;

            ISqlGenerator generator = new UpdateGenerator();

            var sql = generator.GenerateSql(testClass);

            Assert.AreEqual("UPDATE TestClass SET Description='Test' WHERE Id = 2", sql);
        }
    }
}
