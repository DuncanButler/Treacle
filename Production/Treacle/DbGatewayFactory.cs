namespace Treacle
{
    public class DbGatewayFactory
    {
        readonly string _connectionString;

        public DbGatewayFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbGateway Create()
        {
            return new DataGateway(_connectionString);
        }
    }
}