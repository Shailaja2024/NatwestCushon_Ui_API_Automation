Feature: ProductBrowsing

@Scenario_01
Scenario: User sees a list of sweets in Browse Sweets section
	Given the user is on the sweet shop home page
	Then the user should be able to see the title 'Welcome to the sweet shop!'
	When the user navigates to the 'Browse Sweets'
	Then the user should see a list of available sweets with their names as below
		| Sweets Names    |
		| Chocolate Cups  |
		| Sherbert Straws |
		| Sherbert Discs  |
		| Bon Bons        |
		| Jellies         |
		| Bubbly          |
		| Drumsticks      |

@Scenario_02
Scenario: User adds a sweet to basket
	Given the user is on the sweet shop home page
	Then the user should be able to see the title 'Welcome to the sweet shop!'
	When the user clicks the 'Add to Basket' button for a sweet 'Chocolate Cups'
	Then the user should be able to see the basket 1
	When the user navigates to the 'Basket'
	Then the user should be able to see the valid 'Your Basket'
	Then the user should be albe to see the your basket is 1
	When the user clicks on empty basket button
	Then the user should be albe to see the your basket is 0

