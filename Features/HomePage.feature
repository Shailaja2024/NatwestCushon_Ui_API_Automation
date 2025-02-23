Feature: HomePage

@Scenario_01
Scenario: Verify the home page
	Given the user is on the sweet shop home page
	Then the user should be able to see the title 'Welcome to the sweet shop!'
	And the user should be able to see the 'Browse Sweets' button
	And the user should be ale to see the below options in the menu bar
		| Options |
		| Sweets  |
		| About   |
		| Login   |
		| Basket  |

@Scenario_02
Scenario Outline: User should be albe to navigate to different pages from homepage
	Given the user is on the sweet shop home page
	Then the user should be able to see the title 'Welcome to the sweet shop!'
	When the user navigates to the '<Menu Option>'
	Then the user should be able to see the valid '<Title>'
Examples:
	| Menu Option | Title              |
	| Sweets      | Browse sweets      |
	| About       | Sweet Shop Project |
	| Login       | Login              |
	| Basket      | Your Basket        |