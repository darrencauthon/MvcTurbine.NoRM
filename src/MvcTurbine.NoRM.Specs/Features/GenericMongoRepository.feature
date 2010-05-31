Feature: Provide a generic mongo repository
	In order to store data
	As a programmer
	I want to store my objects in a mongo repository

Scenario: Add an object to the repository to a collection that does not exist
	Given a mongo db 'TEST' on server 'localhost' on port '27017'
	And the 'Account' collection has not been created
	When I add an account object to the repository
	Then there should be 1 object in the 'Account' collection

Scenario: Add an object to the repository to a collection that already exists
	Given a mongo db 'TEST' on server 'localhost' on port '27017'
	And the 'Account' collection exists
	When I add an account object to the repository
	Then there should be 1 object in the 'Account' collection

Scenario: Update an object to the repository
	Given a mongo db 'TEST' on server 'localhost' on port '27017'
	And an account with id of X exists in the collection
	When I update the name of the account to 'Changed'
	Then the account document with id of X has a name of 'Changed'