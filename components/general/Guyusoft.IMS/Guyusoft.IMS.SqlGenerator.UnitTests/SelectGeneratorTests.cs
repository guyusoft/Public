﻿using NUnit.Framework;

namespace Guyusoft.IMS.SqlGenerator.UnitTests
{
    [TestFixture]
    public class SelectGeneratorTests
    {
        [Test]
        public void SelectGeneratorTest()
        {
            var schemaGenerator = new DbSchemaGenerator();
            var dbFilter = new DbSchemaFilter(schemaGenerator);
            var selectGenerator = new SelectGenerator(schemaGenerator);

            var sql = selectGenerator.Get<TestClass>(2);

            Assert.AreEqual("SELECT Id,Description FROM TestClass WHERE Id = 2", sql);
        }
    }
}
