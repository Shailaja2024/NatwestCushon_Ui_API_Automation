Feature: BasketCheckout


@Scenario_01
Scenario: Checkout functionality
	Given the user is on the sweet shop home page
	Then the user should be able to see the title 'Welcome to the sweet shop!'
	When the user clicks the 'Add to Basket' button for a sweet 'Chocolate Cups'
	Then the user should be able to see the basket 1
	When the user navigates to the 'Basket'
	Then the user should be able to see the valid 'Your Basket'
	Then the user should be albe to see the your basket is 1
	When the user enters details to billing adress
		| Field      | Value            |
		| First name | ABCDEF           |
		| Last name  | GHIJK            |
		| Email      | test@example.com |
		| Address    | 1234 Main st     |
		| Zip        | 1234             |
	When the user selects an option from the below dripdowns
		| Dropdown | Value          |
		| Country  | United Kingdom |
		| City     | Bristol        |
	When the user enters details to Payment
		| Field              | Value  |
		| Name on card       | ABED   |
		| Credit card number | 123123 |
		| Expiration         | 1226   |
		| CVV                | 213    |
	When the user click on the 'Continue to checkout' button
	Then the user should be albe to see the your basket is 0	