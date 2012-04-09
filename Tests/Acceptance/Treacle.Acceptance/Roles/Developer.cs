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
                dc.spTruncate();
        }

        public IDbGateway Gateway { get; set; }
        public string StringResult { get; private set; }
        public IDataReader ReaderResult { get; private set; }
        public ConnectionState ConnectionState { get { return Gateway.Connection.State; } }

        public void CreateGatewayFactory()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TestDb"].ConnectionString;

            _dbGatewayFactory = new DbGatewayFactory(connectionString);
        }

        public void CreateDatabaseGateway()
        {
            Gateway = _dbGatewayFactory.Create();
        }

        public void ExecuteScaller(string procedureName)
        {
            StringResult = (string)Gateway.ExecuteScaller(procedureName);
        }

        public void ExecuteSelect(string procedureName)
        {
            ReaderResult = Gateway.ExecuteSP(procedureName);
        }

        public void CallDispose()
        {
            Gateway.Dispose();
        }
    }
}