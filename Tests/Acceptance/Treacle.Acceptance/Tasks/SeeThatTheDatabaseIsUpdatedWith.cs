using System.Linq;
using SpecSalad;
using Treacle.Tests;

namespace Treacle.Acceptance.Tasks
{
    public class SeeThatTheDatabaseIsUpdatedWith : ApplicationTask
    {
        public override object Perform_Task()
        {            
            using (var db = new TestDatabaseDataContext())
            {
                Table results = (from t in db.Tables select t).FirstOrDefault();

                return results.Name;
            }
        }
    }
}