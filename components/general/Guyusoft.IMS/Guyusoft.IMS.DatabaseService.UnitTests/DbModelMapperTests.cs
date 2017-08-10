using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.DataContract;
using Guyusoft.IMS.SqlGenerator;
using Guyusoft.IMS.SqlGenerator.DataContract;
using NUnit.Framework;
using System.Data;

namespace Guyusoft.IMS.DatabaseService.UnitTests
{
    [TestFixture]
    public class DbModelMapperTests
    {
        [Test]
        public void MapToTest()
        {
            IDbSchemaGenerator _generator = new DbSchemaGenerator();
            IDbModelMapper mapper = new DbModelMapper(_generator);

            var instance = mapper.MapTo<NavigationMenu>(BuildDataSet());

            Assert.IsNotNull(instance);
            Assert.AreEqual(1, instance.Id);
        }

        private DataSet BuildDataSet()
        {
            DataSet ds = new DataSet();

            DataTable dt = new DataTable();

            DataColumn col = new DataColumn("Id", typeof(int));
            dt.Columns.Add(col);

            DataColumn col1 = new DataColumn("Text", typeof(string));
            dt.Columns.Add(col1);

            DataColumn col2 = new DataColumn("Href", typeof(string));
            dt.Columns.Add(col2);

            DataRow rw = dt.NewRow(); 
            rw["Id"] = 1;
            rw["Text"] = "Test1";
            rw["Href"] = "www.sohu.com";
            dt.Rows.Add(rw);

            ds.Tables.Add(dt);

            return ds;
        }
    }
}
