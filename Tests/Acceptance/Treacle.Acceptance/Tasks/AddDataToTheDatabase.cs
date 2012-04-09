using SpecSalad;

namespace Treacle.Acceptance.Tasks
{
    public class AddDataToTheDatabase : ApplicationTask
    {
        public override object Perform_Task()
        {
            IDbGateway gateway = Role.Gateway;

            gateway.AddVarCharInputParameter("@Name","test",4);
            gateway.ExecuteNonQuery("spNonQuery");
            
            ((DataGateway)gateway).Parameters.Clear();

            return null;
        }
    }
}