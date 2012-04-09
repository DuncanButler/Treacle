using System.Configuration;
using System.Linq;
using NUnit.Framework;
using TestRepository;

namespace Treacle.Tests
{
    public class gateway_context : BaseTest
    {
        protected DataGateway _gateway;

        protected override void EstablishContext()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TestDb"].ConnectionString;

            _gateway = new DataGateway(connectionString);

            using (var dc = new TestDataRepositoryDataContext())
            {
                dc.ClearData();
            }
        }
    }

    [TestFixture]
    public class calling_execute_non_query : gateway_context
    {
        protected override void EstablishContext()
        {
            base.EstablishContext();

            _gateway.AddVarCharInputParameter("@name","Test",4);
        }

        protected override void BecauseOf()
        {
            _gateway.ExecuteNonQuery("spNonQuery");
        }

        [Test]
        public void Adds_a_row_to_the_table()
        {
            using (var dc = new TestDataRepositoryDataContext())
            {
                var result = (from d in dc.TestDatas select d);

                result.Count().IsEqualTo(1);
            }
        }
    }
}