using SpecSalad;
using Treacle.Acceptance.Roles;

namespace Treacle.Acceptance.Tasks
{
    public class HaveCreatedTypeof : ApplicationTask
    {
        public override object Perform_Task()
        {
            IDbGateway gateway = Role.Gateway;

            return gateway.GetType();
        }
    }
}