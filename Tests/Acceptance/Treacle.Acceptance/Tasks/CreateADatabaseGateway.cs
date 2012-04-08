using SpecSalad;

namespace Treacle.Acceptance.Tasks
{
    public class CreateADatabaseGateway : ApplicationTask
    {
        public override object Perform_Task()
        {
            Role.CreateDatabaseGateway();

            return null;
        }
    }
}