Feature: Resolve a working mongo repository
	In order to work with mongo data
	As a programmer
	I want to be able to resolve a working mongo repository from the service locator

Scenario: Resolve a class with a dependency on IMongoRepository<T>
	Given a mongo db 'TEST' on server 'localhost' on port '27017'
	And I have a service locator
	When I resolve a class with a dependency on IMongoRepository<Account>
	Then the class should receive an instance of MongoRepository<Account>

Scenario: Resolve a class with two dependencies on IMongoRepository<T>
	Given a mongo db 'TEST' on server 'localhost' on port '27017'
	And I have a service locator
	When I resolve a class with a dependency on IMongoRepository<Account> and IMongoRepository<Product>
	Then the class should receive an instance of MongoRepository<Account>
	And the class should receive an instance of MongoRepository<Product>
