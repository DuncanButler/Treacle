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
            string type = Details.Value_Of("type");

            if (type == "string")
                gateway.AddVarCharInputParameter(name, value, value.Length);

            if (type == "int")
                gateway.AddIntegerInputParameter(name, int.Parse(value));

            return null;
        }
    }
}