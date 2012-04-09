using SpecSalad;

namespace Treacle.Acceptance.Tasks
{
    public class AddAParameterContaining : ApplicationTask
    {
        public override object Perform_Task()
        {
            IDbGateway gateway = Role.Gateway;

            string name = this.Details.Value_Of("parameterName");
            string value = Details.Value_Of("parameterValue");

            gateway.AddVarCharInputParameter(name,value,value.Length);

            return null;
        }
    }
}