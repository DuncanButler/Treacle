using System;
using System.Data;

namespace Treacle
{
    public interface IDbGateway : IDisposable
    {
        void AddIntegerInputParameter(string name, int value);
        void AddVarCharInputParameter(string name, string value, int length);
        void AddDateTimeInputParameter(string name, DateTime value);
     
        void ExecuteNonQuery(string procedureName);
        IDbConnection Connection { get; }
        object ExecuteScaller(string procedureName);
        IDataReader ExecuteSP(string procedureName);
    }
}