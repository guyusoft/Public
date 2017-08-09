using Guyusoft.IMS.DatabaseService.DataContract;
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
            IDbModelMapper mapper = new DbModelMapper();

            var instance = mapper.MapTo<TestMapperClass>(BuildDataSet());

            Assert.IsNotNull(instance);
        }

        private DataSet BuildDataSet()
        {
            DataSet ds = new DataSet();

            DataTable dt = new DataTable();

            DataColumn col = new DataColumn("Id", typeof(int));
            dt.Columns.Add(col);

            DataColumn col1 = new DataColumn("Desc", typeof(string));
            dt.Columns.Add(col1);

            DataRow rw = dt.NewRow(); 
            rw["Id"] = 1;
            rw["Desc"] = "Test1";
            dt.Rows.Add(rw);

            ds.Tables.Add(dt);

            return ds;
        }

        public class TestMapperClass
        {
            public int Id { get; set; }

            public string Desc { get; set; }
        }
    }
}
