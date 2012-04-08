using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Treacle
{
    public class DataGateway : IDbGateway
    {
        readonly string _connectionString;
        List<IDataParameter> _dataParameters;

        public DataGateway(string connectionString)
        {
            _connectionString = connectionString;
            _dataParameters = new List<IDataParameter>();
        }

        public void AddParameter(string parameterName, object value)
        {
            _dataParameters.Add(new SqlParameter(parameterName,value));
        }
    }
}