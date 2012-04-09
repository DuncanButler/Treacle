using SpecSalad;

namespace Treacle.Acceptance.Tasks
{
    public class ExecuteAScallerProcedure : ApplicationTask
    {
        public override object Perform_Task()
        {
            Role.ExecuteScaller(Details.Value_Of("name"));

            return null;
        }
    }
}