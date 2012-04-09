using System.Configuration;
using System.Data;
using SpecSalad;
using TestRepository;

namespace Treacle.Acceptance.Roles
{
    public class Developer : ApplicationRole
    {
        DbGatewayFactory _dbGatewayFactory;

        public Developer()
        {
            using (var dc = new TestDataRepositoryDataContext())
                dc.ClearData();
        }

        public void CreateGatewayFactory()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TestDb"].ConnectionString;

            _dbGatewayFactory = new DbGatewayFactory(connectionString);
        }

        public IDbGateway Gateway { get; set; }

        public void CreateDatabaseGateway()
        {
            Gateway = _dbGatewayFactory.Create();
        }

        public void AddParameter(string parameterName, int value)
        {
            Gateway.AddIntegerInputParameter(parameterName, value);
        }

        public ConnectionState DatabaseConnectionClosed()
        {
            return Gateway.Connection.State;
        }
    }
}