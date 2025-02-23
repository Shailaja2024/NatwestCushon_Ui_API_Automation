using NatwestCushon_Automation_Test.Support;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace NatwestCushon_Automation_Test.APITest
{
    public class ApiTesting(ScenarioContext scenarioContext)
    {
        private readonly ScenarioContext _scenarioContext = scenarioContext;
        private string _authToken;
        private int _statusCode;
        private string _responseMessage;
        private string _actualErrorMessage;
        public RestResponse _response_body;
        private string _id;

        public void GenerateToken(string baseurl, string api, string email, string password)
        {
            var client = new RestClient(baseurl);
            var request = new RestRequest(api, Method.Post);
            request.AddParameter("email", email);
            request.AddParameter("password", password);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                JObject jsonResponse = JObject.Parse(response.Content);
                _authToken = jsonResponse["token"]?.ToString();

                Console.WriteLine("Token generated successfully: " + _authToken);
            }
            else
            {
                Console.WriteLine("Failed to generate token.");
                Console.WriteLine("Error: " + response.ErrorMessage);
            }
        }
        public string GetJsonResponse(RestResponse response, string responseObject)
        {
            var obs = JObject.Parse(response.Content);
            return obs[responseObject].ToString();
        }
        // Get Response With Object and Array
        public RestResponse GetResponseObjectArray(string baseurl, string api)
        {
            var client = new RestClient(baseurl);
            var request = new RestRequest(api);
            request.AddHeader("Authorization", "Bearer " + _authToken);
            var response_body = client.Execute(request);
            var statusCode = response_body.StatusCode;
            _statusCode = (int)statusCode;
            return response_body;
        }
        public void GetRequest(string baseurl, string api)
        {
            var response = GetResponseObjectArray(baseurl, api);
            var responseBody = response.Content.ToString();
            _response_body = response;
            if (response.IsSuccessful)
            {
                Console.WriteLine("Request was successful. Response: " + response.Content);
            }
            else
            {
                Console.WriteLine("Failed request. Error: " + response.ErrorMessage);
            }
        }
        public void SendARequestWithAnInvalidToken(string baseurl, string api, string invalidToken)
        {
            var client = new RestClient(baseurl);
            var request = new RestRequest(api);
            request.AddHeader("Authorization", "Bearer " + invalidToken);
            var response_body = client.Execute(request);
            var statusCode = response_body.StatusCode;
            _responseMessage = statusCode.ToString();
            _statusCode = (int)statusCode;
            var jsonResponse = JObject.Parse(response_body.Content);
            _actualErrorMessage = jsonResponse["error"]?.ToString();
        }
        public void VerifyStatusCode(int statusCode)
        {
            Assert.AreEqual(statusCode, _statusCode, $"Expected {statusCode} but got {_statusCode}");
        }
        public void ResponseBodyShouldContainAnErrorMessage(string errorMessage)
        {
            Assert.AreEqual(errorMessage, _actualErrorMessage, "Error message mismatch!");
        }
        public List<string> GetDetailsFromJsonResponse(RestResponse response, string key)
        {
            JObject jsonObject = JObject.Parse(response.Content);

            var list = new List<string>();
            foreach (var airport in jsonObject["data"])
            {
                list.Add(airport["attributes"][key].ToString());
                Console.WriteLine(airport["attributes"][key]);
            }
            return list;
        }
        public void VerifyTheAirportList(DataTable dataTable)
        {
            var airportNames = GetDetailsFromJsonResponse(_response_body, "name");
            var expectedAirportNames = ReusableSetMethods.AsStrings(dataTable, "List");

            foreach (var expectedName in expectedAirportNames)
            {
                Assert.IsTrue(airportNames.Contains(expectedName));
                Console.WriteLine($"Assertion Passed: {expectedName} exists in the response.");
            }
        }
        public string? GetValuesFromResponse(string responseContent, string key)
        {
            try
            {
                JToken jsonResponse = JToken.Parse(responseContent);
                _id = jsonResponse["data"][0]["id"].ToString();
                string value = jsonResponse["data"]["attributes"][key]?.ToString();
                Console.WriteLine($"City: {value}");
                return value;
            }
            catch (Exception)
            {
                JToken jsonResponse = JToken.Parse(responseContent);
                JToken data = jsonResponse["data"];
                if (data is JArray dataArray && dataArray.Count > 0)
                {
                    string value = dataArray[0]["attributes"]?["note"]?.ToString(); 
                    Console.WriteLine($"Note: {value}");
                    return value;
                }
                else
                {
                    Console.WriteLine("Data array is empty or missing.");
                    return null;
                }
            }
        }
        public void VerifyResponseWithDetails(DataTable table)
        {
            var properties = ReusableSetMethods.GetKeyValuesFromTable(table, "Keys", "Values");
            foreach (var property in properties)
            {
                var actualValue = GetValuesFromResponse(_response_body.Content, property.Key);
                Assert.AreEqual(property.Value, actualValue);
                Console.WriteLine($"{property.Value} - {actualValue}");
            }
        }
        public void SendAPostRequestWithQueryParams(string baseurl, string api, string param1, string code1, string param2, string code2)
        {
            var client = new RestClient(baseurl);
            var request = new RestRequest(api, Method.Post);
            request.AddParameter(param1, code1, ParameterType.QueryString);
            request.AddParameter(param2, code2, ParameterType.QueryString);
            request.AddHeader("Authorization", "Bearer " + _authToken);
            request.AddHeader("Content-Type", "application/json");
            _response_body = client.Execute(request);
            var statusCode = _response_body.StatusCode;
            _statusCode = (int)statusCode;
            _responseMessage = statusCode.ToString();
        }
        public void SendDeleteRequestToRemoveFavourite(string baseurl, string api)
        {
            var client = new RestClient(baseurl);
            var request = new RestRequest(api + _id, Method.Delete);
            request.AddHeader("Authorization", "Bearer " + _authToken);
            _response_body = client.Execute(request);
            var statusCode = _response_body.StatusCode;
            _statusCode = (int)statusCode;
            _responseMessage = statusCode.ToString();
        }
        public void VerifyTheDistanceBetweenTwoAirports(DataTable table)
        {
            var properties = ReusableSetMethods.GetKeyValuesFromTable(table, "Key", "Value");
            foreach (var property in properties)
            {
                var actualValue = GetValuesFromResponse(_response_body.Content, property.Key);
                Assert.AreEqual(property.Value, actualValue);
                Console.WriteLine($"{property.Value} - {actualValue}");
            }
        }
        public void SendPatchRequestToUpdateFavourites(string baseurl, string api, string id, string note)
        {
            var client = new RestClient(baseurl);
            var request = new RestRequest(api + _id, Method.Patch);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("id", id, ParameterType.QueryString);
            request.AddParameter("note", note, ParameterType.QueryString);
            request.AddHeader("Authorization", "Bearer " + _authToken);
            _response_body = client.Execute(request);
            var statusCode = _response_body.StatusCode;
            _statusCode = (int)statusCode;
            _responseMessage = statusCode.ToString();
        }
        public void VerifyTheUpdatedNotesInTheReponse(string note)
        {
            var actualNote = GetValuesFromResponse(_response_body.Content, "note");
            Assert.AreEqual(note, actualNote);
            Console.WriteLine($"{note} - {actualNote}");
        }       
        public void ClearAllFavourites(string baseurl, string api)
        {
            var client = new RestClient(baseurl);
            var request = new RestRequest(api, Method.Delete);
            request.AddHeader("Authorization", "Bearer " + _authToken);
            _response_body = client.Execute(request);
            var statusCode = _response_body.StatusCode;
            _statusCode = (int)statusCode;
            _responseMessage = statusCode.ToString();
        }

    }
}
