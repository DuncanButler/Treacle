using System;
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

        public IDbConnection Connection { get; private set; }

        public void AddIntegerInputParameter(string name, int value)
        {
            Parameters.Add(new SqlParameter(name, SqlDbType.Int) {Value = value, Direction = ParameterDirection.Input});
        }

        public void AddVarCharInputParameter(string name, string value, int length)
        {
            Parameters.Add(new SqlParameter(name, SqlDbType.NVarChar,length){Value = value,Direction = ParameterDirection.Input});
        }

        public void AddDateTimeInputParameter(string name, DateTime value)
        {
            Parameters.Add(new SqlParameter(name,SqlDbType.DateTime){Value = value,Direction = ParameterDirection.Input});
        }

        public void ExecuteNonQuery(string procedureName)
        {
            CreateConnection();

            var command = CreateCommand(procedureName);

            AddParameters(command);

            OpenConnection();

            command.ExecuteNonQuery();
            
            CloseConnection();
        }

        public object ExecuteScaller(string procedureName)
        {
            CreateConnection();

            var command = CreateCommand(procedureName);

            AddParameters(command);

            OpenConnection();
            
            var scalar = command.ExecuteScalar();
            
            CloseConnection();

            return scalar;
        }

        public IDataReader ExecuteSP(string procedureName)
        {
            CreateConnection();

            var command = CreateCommand(procedureName);

            AddParameters(command);

            OpenConnection();

            return command.ExecuteReader();
        }

        void CreateConnection()
        {
            Connection = new SqlConnection(_connectionString);
        }

        void AddParameters(IDbCommand command)
        {
            foreach (var parameter in Parameters)
            {
                command.Parameters.Add(parameter);
            }
        }

        IDbCommand CreateCommand(string procedureName)
        {
            var command = Connection.CreateCommand();
            command.CommandText = procedureName;
            command.CommandType = CommandType.StoredProcedure;
            
            return command;
        }

        void OpenConnection()
        {
            Connection.Open();
        }

        void CloseConnection()
        {
            if (Connection == null) 
                return;

            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}