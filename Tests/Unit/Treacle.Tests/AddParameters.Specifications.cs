using System.Data;
using System.Data.SqlClient;
using NUnit.Framework;

namespace Treacle.Tests
{
    public class adding_string_parameters_to_the_gateway : adding_parameters_context
    {
        protected override void BecauseOf()
        {
            _gateway.AddVarCharInputParameter(_name, _stringValue, _stringValue.Length);
        }

        [Test]
        public void adds_a_parameter_with_the_correct_name()
        {
            ((DataGateway)_gateway).Parameters[0].ParameterName.IsEqualTo(_name);
        }

        [Test]
        public void adds_a_parameter_with_the_correct_size()
        {
            var param = (SqlParameter) ((DataGateway) _gateway).Parameters[0];

            param.Size.IsEqualTo(_stringValue.Length);
        }

        [Test]
        public void adds_a_parameter_with_the_correct_value()
        {
            ((DataGateway)_gateway).Parameters[0].Value.IsEqualTo(_stringValue);
        }

        [Test]
        public void adds_a_parameter_with_the_correct_sql_type()
        {
            ((DataGateway)_gateway).Parameters[0].DbType.IsEqualTo(DbType.String);
        }

        [Test]
        public void adds_a_parameter_with_the_correct_parameter_direction()
        {
            ((DataGateway)_gateway).Parameters[0].Direction.IsEqualTo(ParameterDirection.Input);
        }
    }

    public class adding_int_parameters_to_the_gateway : adding_parameters_context
    {
        protected override void BecauseOf()
        {
            _gateway.AddIntegerInputParameter(_name, _intValue);
        }

        [Test]
        public void adds_a_parameter_with_the_correct_name()
        {
            ((DataGateway)_gateway).Parameters[0].ParameterName.IsEqualTo(_name);
        }

        [Test]
        public void adds_a_parameter_with_the_correct_value()
        {
            ((DataGateway)_gateway).Parameters[0].Value.IsEqualTo(_intValue);
        }

        [Test]
        public void adds_a_parameter_with_the_correct_sql_type()
        {
            ((DataGateway)_gateway).Parameters[0].DbType.IsEqualTo(DbType.Int32);
        }

        [Test]
        public void adds_a_parameter_with_the_correct_parameter_direction()
        {
            ((DataGateway)_gateway).Parameters[0].Direction.IsEqualTo(ParameterDirection.Input);
        }
    }

    public class adding_parameters_context : BaseTest
    {
        protected IDbGateway _gateway;
        protected string _name;
        protected int _intValue;
        protected string _stringValue;

        protected adding_parameters_context()
        {
            Describes("adding parameters to the data gateway");
        }

        protected override void EstablishContext()
        {
            string connectionString = null;

            _gateway = new DataGateway(connectionString);
            _name = "@test";
            _intValue = 1;
            _stringValue = "one";
        }
    }
}