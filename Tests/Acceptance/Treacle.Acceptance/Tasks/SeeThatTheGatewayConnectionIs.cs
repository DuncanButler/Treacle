using SpecSalad;

namespace Treacle.Acceptance.Tasks
{
    public class SeeThatTheGatewayConnectionIs : ApplicationTask
    {
        public override object Perform_Task()
        {
            return Role.DatabaseConnectionClosed();
        }
    }
}