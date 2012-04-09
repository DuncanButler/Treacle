using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Treacle
{
    public class DataGateway : IDbGateway
    {
        readonly string _connectionString;

        public DataGateway(string connectionString)
        {
            _connectionString = connectionString;
            Parameters = new List<IDataParameter>();
        }

        public IList<IDataParameter> Parameters { get; private set; }
        
        public void AddIntegerInputParameter(string name, int value)
        {
            Parameters.Add(new SqlParameter(name, SqlDbType.Int) {Value = value, Direction = ParameterDirection.Input});
        }

        public void AddVarCharInputParameter(string name, string value, int length)
        {
            Parameters.Add(new SqlParameter(name, SqlDbType.NVarChar,length){Value = value,Direction = ParameterDirection.Input});
        }

        public void ExecuteNonQuery(string procedureName)
        {
            //var connection = new SqlConnection(_connectionString);
            //var command = connection.CreateCommand();
            //command.CommandText = procedureName;
            //command.CommandType = CommandType.StoredProcedure;

            //foreach (var parameter in Parameters)
            //{
            //    command.Parameters.Add(parameter);
            //}

            //connection.Open();
            //command.ExecuteNonQuery();
            //connection.Close();
        }
    }
}