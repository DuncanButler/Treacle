using SpecSalad;

namespace Treacle.Acceptance.Tasks
{
    public class CallDispose : ApplicationTask
    {
        public override object Perform_Task()
        {
            Role.CallDispose();

            return null;
        }
    }
}