using System.Configuration;
using System.Data;
using SpecSalad;

namespace Treacle.Acceptance.Roles
{
    public class Developer : ApplicationRole
    {
        DbGatewayFactory _dbGatewayFactory;

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

        public void AddParameter(string parameterName, SqlDbType value)
        {
            Gateway.AddParameter(parameterName, value);
        }
    }
}