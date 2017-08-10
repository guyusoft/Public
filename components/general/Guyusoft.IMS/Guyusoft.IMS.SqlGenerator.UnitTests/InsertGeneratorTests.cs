using NUnit.Framework;

namespace Guyusoft.IMS.SqlGenerator.UnitTests
{
    [TestFixture]
    public class InsertGeneratorTests
    {
        [Test]
        public void InsertGeneratorTest()
        {
            var testClass = new TestClass();
            testClass.Description = "Test";

            var schemaGenerator = new DbSchemaGenerator();
            var dbFilter = new DbSchemaFilter(schemaGenerator);
            var generator = new InsertGenerator(schemaGenerator, dbFilter);

            var sql = generator.Get<TestClass>(testClass);

            Assert.AreEqual("INSERT INTO TestClass (Description) VALUES ('Test'); SELECT @@IDENTITY", sql);
        }
    }
}
