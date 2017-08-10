using NUnit.Framework;

namespace Guyusoft.IMS.SqlGenerator.UnitTests
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

            var schemaGenerator = new DbSchemaGenerator();
            var dbFilter = new DbSchemaFilter();
            var generator = new UpdateGenerator(schemaGenerator, dbFilter);

            var sql = generator.Get<TestClass>(testClass);

            Assert.AreEqual("UPDATE TestClass SET Description='Test' WHERE Id = 2", sql);
        }
    }
}
