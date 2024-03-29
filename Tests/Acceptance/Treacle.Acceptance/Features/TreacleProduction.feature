﻿Feature: Treacle production
	As a developer I want an easy way to access database stored procedures
	That unlike Linq or Entity Framework the product will use stright calls
	to the stored procedures with parameters.

	The factory will produce gateways so we can abstract them away and produce mock 
	gateway implementations, that can return structured data.

@TreacleFactory
Scenario: calling create on the factory creates a new instance of the data gateway with an open connection
	Given I am a developer
	And I did create a gateway factory
	When I attempt to create a database gateway
	Then I should have created typeof 'Treacle.DataGateway'

@TreacleDBGateway
Scenario: adding a parameter to the gateway
	Given I am a developer
	And I did create a gateway factory
	And I did create a database gateway
	When I attempt to add a database parameter to the gateway
	Then I should see the gateway parameters count equal '1'

@TreacleDBGateway
Scenario: calling a stored procedure that returns nothing
	Given I am a developer
	And I did create a gateway factory
	And I did create a database gateway
	And I did add a parameter containing, parameterName '@name' parameterValue 'test' type 'string'
	When I attempt to execute the procedure, procedureName 'spNonQuery'
	Then I should see that the database is updated with 'test'
	And I should see that the gateway connection is 'Closed'

@TreacleDBGateway
Scenario: calling a stored procedure that returns a single result
	Given I am a developer
	And I did create a gateway factory
	And I did create a database gateway
	And I did add data to the database
	And I did add a parameter containing, parameterName '@Id' parameterValue '1' type 'integer'
	When I attempt to execute a scaller procedure, name 'spExecuteScaller'
	Then I should see the result 'test'
	And I should see that the gateway connection is 'Closed'

@TreacleDBGateway
Scenario: calling a stored procedure that returns multiple rows
	Given I am a developer
	And I did create a gateway factory
	And I did create a database gateway
	And I did add data to the database
	When I attempt to execute a select procedure, name 'spSelect'
	Then I should have received an object of type 'System.Data.SqlClient.SqlDataReader'
	And I should see that the gateway connection is 'Open'
	And I should see that the reader has rows

@TreacleDBGateway
Scenario: calling dispose closes any open connections
	Given I am a developer
	And I did create a gateway factory
	And I did create a database gateway
	And I did execute a select procedure, name 'spSelect'
	When I attempt to call dispose
	Then I should see that the gateway connection is 'Closed'