using SpecSalad;

namespace Treacle.Acceptance.Tasks
{
    public class ExecuteASelectProcedure : ApplicationTask
    {
        public override object Perform_Task()
        {
            var name = Details.Value_Of("name");

            Role.ExecuteSelect(name);

            return null;
        }
    }
}