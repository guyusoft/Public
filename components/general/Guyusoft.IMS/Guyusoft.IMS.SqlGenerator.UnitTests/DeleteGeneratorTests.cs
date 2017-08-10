using NUnit.Framework;

namespace Guyusoft.IMS.SqlGenerator.UnitTests
{
    [TestFixture]
    public class DeleteGeneratorTests
    {
        [Test]
        public void DeleteGeneratorTest()
        {
            var schemaGenerator = new DbSchemaGenerator();
            var generator = new DeleteGenerator(schemaGenerator);

            var sql = generator.Get<TestClass>(2);

            Assert.AreEqual("DELETE FROM TestClass WHERE Id = 2", sql);
        }
    }
}
