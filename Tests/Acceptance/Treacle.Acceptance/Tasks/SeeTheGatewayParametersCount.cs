using SpecSalad;

namespace Treacle.Acceptance.Tasks
{
    public class SeeTheGatewayParametersCountEqual : ApplicationTask
    {
        public override object Perform_Task()
        {
            DataGateway gateway = Role.Gateway;

            return gateway.Parameters.Count;
        }
    }
}