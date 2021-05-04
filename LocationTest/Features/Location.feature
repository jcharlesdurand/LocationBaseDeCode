Feature: Location

Background: 
	Given following existing clients
	| Username | Password |
	| jcharles | toto     |
	

Scenario: Client connection - Username not recognized
	Given my username is "jean-charles"
	And my password is "toto"
	When I try to connect to my account
	Then the connection is refused
	And the error message is "Username not recognized"

Scenario: Client connection - Username recognized
	Given my username is "jcharles"
	And my password is "toto"
	When I try to connect to my account
	Then the connection is established

Scenario: Client connection - Username recognized but incorrect password
	Given my username is "jcharles"
	And my password is "toto111"
	When I try to connect to my account
	Then the connection is refused
	And the error message is "Incorrect password"
