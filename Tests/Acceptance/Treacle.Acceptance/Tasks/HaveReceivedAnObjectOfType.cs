using SpecSalad;

namespace Treacle.Tests
{
    public class HaveReceivedAnObjectOfType : ApplicationTask
    {
        public override object Perform_Task()
        {
            return Role.ReaderResult.GetType();
        }
    }
}