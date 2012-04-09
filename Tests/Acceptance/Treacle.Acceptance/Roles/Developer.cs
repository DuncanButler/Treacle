﻿using System.Configuration;
using System.Data;
using SpecSalad;
using TestRepository;

namespace Treacle.Acceptance.Roles
{
    public class Developer : ApplicationRole
    {
        DbGatewayFactory _dbGatewayFactory;
        string _resultOfPreviousCall;

        public Developer()
        {
            using (var dc = new TestDataRepositoryDataContext())
                dc.spTruncate();
        }

        public void CreateGatewayFactory()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TestDb"].ConnectionString;

            _dbGatewayFactory = new DbGatewayFactory(connectionString);
        }

        public IDbGateway Gateway { get; set; }

        public void CreateDatabaseGateway()
        {
            Gateway = _dbGatewayFactory.Create();
        }

        public ConnectionState DatabaseConnectionClosed()
        {
            return Gateway.Connection.State;
        }

        public void ExecuteScaller(string procedureName)
        {
            _resultOfPreviousCall = (string) Gateway.ExecuteScaller(procedureName);
        }

        public string ResultOfPreviousCall()
        {
            return _resultOfPreviousCall.Trim();
        }
    }
}