Feature: Provide a generic mongo repository
	In order to store data
	As a programmer
	I want to store my objects in a mongo repository

Scenario: Add an object to the repository to a collection that does not exist
	Given a mongo db 'TEST' on server 'localhost' on port ''
	And the 'Account' collection has not been created
	When I add an account object to the repository
	Then there should be 1 object in the 'Account' collection


