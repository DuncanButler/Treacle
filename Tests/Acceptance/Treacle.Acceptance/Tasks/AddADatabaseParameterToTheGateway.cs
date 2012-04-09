using SpecSalad;

namespace Treacle.Acceptance.Tasks
{
    public class AddADatabaseParameterToTheGateway : ApplicationTask    
    {
        public override object Perform_Task()
        {
            IDbGateway gateway = Role.Gateway;

            gateway.AddIntegerInputParameter("@test",1);
            
            return null;
        }
    }
}