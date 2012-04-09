using SpecSalad;

namespace Treacle.Acceptance.Tasks
{
    public class SeeTheResult : ApplicationTask
    {
        public override object Perform_Task()
        {
            return Role.StringResult.Trim();
        }
    }
}