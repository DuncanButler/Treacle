using SpecSalad;

namespace Treacle.Acceptance.Tasks
{
    public class AddADatabaseParameterToTheGateway : ApplicationTask    
    {
        public override object Perform_Task()
        {
            Role.AddParameter("@test",1);

            return null;
        }
    }
}