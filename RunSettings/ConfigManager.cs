using Microsoft.Extensions.Configuration;
namespace NatwestCushon_Automation_Test.RunSettings
{
    class ConfigManager
    {
        private readonly IConfiguration _configuration;
        public ConfigManager()
        {
            // Load configuration from runsettings.json
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("runsettings.json")
                .Build();
        }
        public string GetBaseUrl()
        {
            return _configuration["TestSettings:BaseUrl"];
        }

        public string GetUsername()
        {
            return _configuration["TestSettings:Username"];
        }

        public string GetPassword()
        {
            return _configuration["TestSettings:Password"];
        }
        public string GetInvalidUsername()
        {
            return _configuration["TestSettings:Invalid UserName"];
        }
        public string GetInvalidPassword()
        {
            return _configuration["TestSettings:Invalid Password"];
        }
        public string GetClient()
        {
            return _configuration["ApiTestSettings:Client"];
        }
        public string GetApiEmail()
        {
            return _configuration["ApiTestSettings:ApiEmail"];
        }
        public string GetApiPassword()
        {
            return _configuration["ApiTestSettings:ApiPassword"];
        }
        public string GetTokenApi()
        {
            return _configuration["ApiTestSettings:TokenApi"];
        }
    }
}
