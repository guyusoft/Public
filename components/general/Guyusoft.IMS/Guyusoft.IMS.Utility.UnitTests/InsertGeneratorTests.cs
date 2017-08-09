using Guyusoft.IMS.Utility.DataContract.SQLGenerator;
using Guyusoft.IMS.Utility.SQLGenerator;
using NUnit.Framework;

namespace Guyusoft.IMS.Utility.UnitTests
{
    [TestFixture]
    public class InsertGeneratorTests
    {
        [Test]
        public void InsertGeneratorTest()
        {
            var testClass = new TestClass();
            testClass.Description = "Test";

            ISqlGenerator generator = new InsertGenerator();

            var sql = generator.GenerateSql(testClass);

            Assert.AreEqual("INSERT INTO TestClass (Description) VALUES ('Test')", sql);
        }
    }
}
