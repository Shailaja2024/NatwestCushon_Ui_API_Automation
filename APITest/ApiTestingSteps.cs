using NatwestCushon_Automation_Test.RunSettings;

namespace NatwestCushon_Automation_Test.APITest
{
    [Binding]
    public class ApiTestingSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ApiTesting _apiTesting;
        private readonly ConfigManager _configManager;
        public ApiTestingSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _apiTesting = new ApiTesting(scenarioContext);
            _configManager = new ConfigManager();
        }
        [Given("the user have a valid token")]
        public void GivenTheUserHaveAValidToken()
        {
            _apiTesting.GenerateToken(_configManager.GetClient(), _configManager.GetTokenApi(), _configManager.GetApiEmail(), _configManager.GetApiPassword());
        }
        [When("the user makes a Get request to '(.*)'")]
        public void WhenTheUserMakesAGetRequestTo(string api)
        {
            _apiTesting.GetRequest(_configManager.GetClient(), api);
        }
        [Then("the response status should be {int}")]
        public void ThenTheResponseStatusShouldBe(int statusCode)
        {
            _apiTesting.VerifyStatusCode(statusCode);
        }
        [When("the user send a Get request to '(.*)' with an invalid token '(.*)'")]
        public void WhenTheUserSendAGetRequestToWithAnInvalidToken(string api, string invalidToken)
        {
            _apiTesting.SendARequestWithAnInvalidToken(_configManager.GetClient(), api, invalidToken);
        }
        [Then("the response body should contain an error message '(.*)'")]
        public void ThenTheResponseBodyShouldContainAnErrorMessage(string errorMessage)
        {
            _apiTesting.ResponseBodyShouldContainAnErrorMessage(errorMessage);
        }
        [Then("the response should contain a list of airports")]
        public void ThenTheResponseShouldContainAListOfAirports(DataTable dataTable)
        {
            _apiTesting.VerifyTheAirportList(dataTable);
        }
        [Then("the response body should contain below details")]
        public void ThenTheResponseBodyShouldContainBelowDetails(DataTable dataTable)
        {
            _apiTesting.VerifyResponseWithDetails(dataTable);
        }
        [When("the  user sends a POST request to '(.*)' find distance between airport codes '(.*)' and '(.*)'")]
        public void WhenTheUserSendsAPOSTRequestToFindDistanceBetweenAirportCodesAnd(string api, string code1, string code2)
        {
            var param1 = "from";
            var param2 = "to";
            _apiTesting.SendAPostRequestWithQueryParams(_configManager.GetClient(), api, param1, code1, param2, code2);
        }
        [Then("the response should contain the distance between airports")]
        public void ThenTheResponseShouldContainTheDistanceBetweenAirports(DataTable dataTable)
        {
            _apiTesting.VerifyTheDistanceBetweenTwoAirports(dataTable);
        }
        [When("the user makes a Post request to '(.*)' with id '(.*)' and note '(.*)' parameters")]
        public void WhenTheUserMakesAPostRequestToWithIdAndNoteParameters(string api, string id, string note)
        {
            var param1 = "airport_id";
            var param2 = "note";
            _apiTesting.SendAPostRequestWithQueryParams(_configManager.GetClient(), api, param1, id, param2, note);
        }
        [When("user makes a Patch request to '(.*)' update with id '(.*)' and the notes as '(.*)'")]
        public void WhenUserMakesAPatchRequestToUpdateWithIdAndTheNotesAs(string api, string id, string note)
        {
            _apiTesting.SendPatchRequestToUpdateFavourites(_configManager.GetClient(), api, id, note);
        }
        [Then("the response body should contain the updates notes as '(.*)'")]
        public void ThenTheResponseBodyShouldContainTheUpdatesNotesAs(string note)
        {
            _apiTesting.VerifyTheUpdatedNotesInTheReponse(note);
        }
        [When("user makes a Delete request to remove the '(.*)' along with id")]
        public void WhenUserMakesADeleteRequestToRemoveTheAlongWithId(string api)
        {
            _apiTesting.SendDeleteRequestToRemoveFavourite(_configManager.GetClient(), api);
        }
        [When("user makes a Delete request to '(.*)' to remove all favourites")]
        public void WhenUserMakesADeleteRequestToToRemoveAllFavourites(string api)
        {
            _apiTesting.ClearAllFavourites(_configManager.GetClient(), api);
        }
    }
}
