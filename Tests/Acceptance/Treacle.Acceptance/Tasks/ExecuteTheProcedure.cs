using SpecSalad;

namespace Treacle.Acceptance.Tasks
{
    public class ExecuteTheProcedure : ApplicationTask
    {
        public override object Perform_Task()
        {
            IDbGateway gateway = Role.Gateway;

            string procedureName = Details.Value_Of("procedureName");

            gateway.ExecuteNonQuery(procedureName);

            return null;
        }
    }
}