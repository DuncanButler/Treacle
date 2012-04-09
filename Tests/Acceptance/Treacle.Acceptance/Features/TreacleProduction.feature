Feature: Treacle production
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
	And I did add a parameter containing, parameterName '@name' parameterValue 'test'
	When I attempt to execute the procedure, procedureName 'spInsertName'
	Then I should see that the database is updated with 'the name Duncan'
	And I should see that the gateway connection is 'closed'

@TreacleDBGateway
Scenario: calling a stored procedure that returns a single result
	Given I am a developer
	And I did create a gateway factory
	And I did create a database gateway
	When I execute scaller the procedure, name 'spScaller'
	Then I should see the result 'expected'
	And I should see that the gateway connection is 'closed'

@TreacleDBGateway
Scenario: calling a stored procedure that returns multiple rows
	Given I am a developer
	And I did create a gateway factory
	And I did create a database gateway
	When I execute the procedure, name 'spReaderResult'
	Then I should have received 'an IDbReader object'
	And I should see that the gateway connection is 'open'