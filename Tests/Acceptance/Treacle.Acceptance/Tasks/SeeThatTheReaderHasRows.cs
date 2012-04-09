using SpecSalad;

namespace Treacle.Acceptance.Tasks
{
    public class SeeThatTheReaderHasRows : ApplicationTask
    {
        public override object Perform_Task()
        {
            return Role.ReaderResult.HasRows;
        }
    }
}