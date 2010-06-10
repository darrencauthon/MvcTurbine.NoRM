Feature: Resolve a working mongo repository
	In order to work with mongo data
	As a programmer
	I want to be able to resolve a working mongo repository from the many Turbine service locators

Scenario: Resolve a class with a dependency on IMongoRepository<T>
	Given a mongo db 'TEST' on server 'localhost' on port '27017'
	And I have a Unity service locator
	And I have spun the NoRM Blade
	When I resolve a class with a dependency on IMongoRepository<Account>
	Then the class should receive an instance of MongoRepository<Account>

Scenario: Resolve a class with a dependency on IMongoRepository<T>
	Given a mongo db 'TEST' on server 'localhost' on port '27017'
	And I have a StructureMap service locator
	And I have spun the NoRM Blade
	When I resolve a class with a dependency on IMongoRepository<Account>
	Then the class should receive an instance of MongoRepository<Account>

Scenario: Resolve a class with a dependency on IMongoRepository<T>
	Given a mongo db 'TEST' on server 'localhost' on port '27017'
	And I have a Ninject service locator
	And I have spun the NoRM Blade
	When I resolve a class with a dependency on IMongoRepository<Account>
	Then the class should receive an instance of MongoRepository<Account>

Scenario: Resolve a class with a dependency on IMongoRepository<T>
	Given a mongo db 'TEST' on server 'localhost' on port '27017'
	And I have a Windsor service locator
	And I have spun the NoRM Blade
	When I resolve a class with a dependency on IMongoRepository<Account>
	Then the class should receive an instance of MongoRepository<Account>
