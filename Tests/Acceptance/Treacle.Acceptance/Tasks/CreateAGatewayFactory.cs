using SpecSalad;

namespace Treacle.Acceptance.Tasks
{
    public class CreateAGatewayFactory : ApplicationTask
    {
        public override object Perform_Task()
        {
            Role.CreateGatewayFactory();

            return null;
        }
    }
}