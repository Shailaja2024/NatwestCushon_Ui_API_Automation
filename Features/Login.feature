Feature: Login
@Scenario_01
Scenario Outline: User attempts to log in with different credentials
	Given the user is on the sweet shop home page
	Then the user should be able to see the title 'Welcome to the sweet shop!'
	When user clicks login button on navigation bar
	When the user enters the username '<Username>'
	And the user enters the password '<Password>'
	And clicks the login button
	Then the user should see '<Message>'

Examples:
	| Username         | Password         | Message                             |
	| Valid UserName   | Valid Password   | Welcome back                        |
	| Invalid UserName | Invalid Password | Please enter a valid email address. |
	| Valid UserName   | Invalid Password | Please enter a valid password.      |
	| Empty            | Empty            | Please enter a valid email address. |