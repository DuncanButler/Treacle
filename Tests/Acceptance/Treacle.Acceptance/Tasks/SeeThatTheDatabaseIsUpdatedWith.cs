using System.Linq;
using SpecSalad;
using TestRepository;
using Treacle.Tests;

namespace Treacle.Acceptance.Tasks
{
    public class SeeThatTheDatabaseIsUpdatedWith : ApplicationTask
    {
        public override object Perform_Task()
        {
            using (var db = new TestDataRepositoryDataContext())
            {
                TestData results = (from t in db.TestDatas select t).FirstOrDefault();

                return results.Name.Trim();
            }
        }
    }
}