
Feature: TokenBasedAuthenticationForAPI

@scenario_01 @api
Scenario: Valid and invalid authentication token
	Given the user have a valid token
	When the user makes a Get request to '/airports'
	Then the response status should be 200
	When the user send a Get request to '/airports' with an invalid token '1234567'
	Then the response status should be 401
	And the response body should contain an error message 'Unauthorized'

@Scenario_02 @api
Scenario: Airports data and validation
	Given the user have a valid token
	When the user makes a Get request to '/airports'
	Then the response status should be 200
	And the response should contain a list of airports
		| List                      |
		| Goroka Airport            |
		| Madang Airport            |
		| Brandon Municipal Airport |
		| Cambridge Bay Airport     |
	When the user makes a Get request to '/airports/MAG'
	Then the response status should be 200
	And the response body should contain below details
		| Keys     | Values               |
		| city     | Madang               |
		| country  | Papua New Guinea     |
		| timezone | Pacific/Port_Moresby |
	When the  user sends a POST request to '/airports/distance' find distance between airport codes 'KIX' and 'GKA'
	Then the response status should be 200
	Then the response should contain the distance between airports
		| Key        | Value            |
		| kilometers | 4628.82980331026 |

@Scenario_03 @api
Scenario: Favourites and Validations
	Given the user have a valid token
	When the user makes a Post request to '/favorites' with id 'GOH' and note 'A very good airport' parameters
	Then the response status should be 201
	When the user makes a Get request to '/favorites'
	Then the response status should be 200
	And the response body should contain below details
		| Keys     | Values               |
		| note     | A very good airport  |
	When user makes a Patch request to '/favorites/' update with id 'GOH' and the notes as 'Its my first favorites'
	Then the response status should be 200
	When user makes a Delete request to remove the '/favorites/' along with id
	Then the response status should be 204
	When the user makes a Post request to '/favorites' with id 'UAK' and note 'A very good airport' parameters
	Then the response status should be 201
	When the user makes a Get request to '/favorites/'
	Then the response status should be 200
	When user makes a Delete request to '/favorites/clear_all' to remove all favourites
	Then the response status should be 204