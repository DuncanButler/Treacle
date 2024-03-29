﻿using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
                dc.spTruncate();
        }

        protected void AddDataToDatabase()
        {
            _gateway.AddVarCharInputParameter("@name", "Test 1", 4);
            _gateway.ExecuteNonQuery("spNonQuery");

            _gateway.Parameters.Clear();
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
        public void adds_a_row_to_the_table()
        {
            using (var dc = new TestDataRepositoryDataContext())
            {
                var result = (from d in dc.TestDatas select d);

                result.Count().IsEqualTo(1);
            }
        }
    }

    [TestFixture]
    public class calling_execute_scaller : gateway_context
    {
        string _result;

        protected override void EstablishContext()
        {
            base.EstablishContext();

            AddDataToDatabase();

            _gateway.AddIntegerInputParameter("@Id", 1);
        }


        protected override void BecauseOf()
        {
            _result = (string) _gateway.ExecuteScaller("spExecuteScaller");
        }

        [Test]
        public void the_result_contains_the_expected_result()
        {
            _result.Trim().IsEqualTo("Test");
        }
    }

    [TestFixture]
    public class calling_select_query : gateway_context
    {
        IDataReader _dataReader;

        protected override void EstablishContext()
        {
            base.EstablishContext();

            AddDataToDatabase();
        }

        protected override void BecauseOf()
        {
            _dataReader = _gateway.ExecuteSP("spSelect");
        }

        [Test]
        public void returns_a_datareader()
        {
            ((SqlDataReader)_dataReader).HasRows.IsTrue();
        }
    }

    [TestFixture]
    class calling_dispose_closes_any_open_connection : gateway_context
    {
        protected override void EstablishContext()
        {
            base.EstablishContext();

            _gateway.ExecuteSP("spSelect");
            
            _gateway.Connection.State.IsEqualTo(ConnectionState.Open);
        }

        protected override void BecauseOf()
        {
            _gateway.Dispose();
        }

        [Test]
        public void connection_is_closed()
        {
            _gateway.Connection.State.IsEqualTo(ConnectionState.Closed);        
        }
    }
}