using ModelLayer.DTO;
using RepositoryLayer.Interface;
using Microsoft.Extensions.Logging;  // ✅ Add logging

namespace RepositoryLayer.Service
{
    public class RegisterHelloRL : IRegistrationHelloRL
    {
        private readonly ILogger<RegisterHelloRL> _logger;  // ✅ Logger instance
        private string databaseUsername = "root";
        private string databasePassword = "root";

        public RegisterHelloRL(ILogger<RegisterHelloRL> logger)  // ✅ Inject logger
        {
            _logger = logger;
        }

        public string GetHello(string name)
        {
            _logger.LogInformation("GetHello method called with name: {Name}", name);  // ✅ Log request
            return name + " Hello from repository layer";
        }

        public LoginDTO getUsernamePassword(LoginDTO loginDTO)
        {
            _logger.LogInformation("Fetching stored username and password for login.");  // ✅ Log access

            loginDTO.username = databaseUsername;
            loginDTO.password = databasePassword;

            _logger.LogInformation("Returning hardcoded credentials for validation.");
            return loginDTO;
        }

        public LoginDTO Database(LoginDTO loginDTO)
        {
            _logger.LogInformation("Fetching database credentials.");

            return new LoginDTO
            {
                username = databaseUsername,
                password = databasePassword
            };
        }
    }
}
