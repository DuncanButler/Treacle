using System.Data;

namespace Treacle
{
    public interface IDbGateway
    {
        void AddParameter(string parameterName, object value);
    }
}