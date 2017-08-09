using Guyusoft.IMS.Utility.DataContract.SQLGenerator;
using Guyusoft.IMS.Utility.SQLGenerator;
using NUnit.Framework;

namespace Guyusoft.IMS.Utility.UnitTests
{
    [TestFixture]
    public class DeleteGeneratorTests
    {
        [Test]
        public void DeleteGeneratorTest()
        {
            var testClass = new TestClass();
            testClass.Id = 2;

            ISqlGenerator generator = new DeleteGenerator();

            var sql = generator.GenerateSql(testClass);

            Assert.AreEqual("DELETE FROM TestClass WHERE Id = 2", sql);
        }
    }
}
