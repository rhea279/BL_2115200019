using RepositoryLayer.Service;
using ModelLayer.DTO;
using BusinessLayer.Interface;
using Microsoft.Extensions.Logging;  // ✅ Add this for logging

namespace BusinessLayer.Service
{
    public class RegisterHelloBL : IRegistrationHelloBL
    {
        private readonly RegisterHelloRL _registerHelloRL;
        private readonly ILogger<RegisterHelloBL> _logger;  // ✅ Logger instance

        public RegisterHelloBL(RegisterHelloRL registerHelloRL, ILogger<RegisterHelloBL> logger)  // ✅ Inject logger
        {
            _registerHelloRL = registerHelloRL;
            _logger = logger;
        }

        public string registration(string name)
        {
            _logger.LogInformation("Registration request received with name: {Name}", name);  // ✅ Log request
            return "Data from repository layer " + _registerHelloRL.GetHello(name);
        }

        public bool loginUser(LoginDTO loginDTO)
        {
            _logger.LogInformation("Login attempt for user: {Username}", loginDTO.username);  // ✅ Log login attempt

            string frontendUser = loginDTO.username;
            string frontendPassword = loginDTO.password;

            LoginDTO result = _registerHelloRL.getUsernamePassword(loginDTO);

            if (result == null)
            {
                _logger.LogWarning("Login failed: User not found - {Username}", frontendUser);  // ✅ Log warning
                return false;
            }

            bool res = checkUsernamePassword(frontendUser, frontendPassword, result);

            if (res)
            {
                _logger.LogInformation("Login successful for user: {Username}", frontendUser);  // ✅ Log success
            }
            else
            {
                _logger.LogWarning("Login failed: Incorrect password for user: {Username}", frontendUser);  // ✅ Log failure
            }

            return res;
        }

        private bool checkUsernamePassword(string frontendUser, string frontendPassword, LoginDTO result)
        {
            return frontendUser.Equals(result.username) && frontendPassword.Equals(result.password);
        }
    }
}
