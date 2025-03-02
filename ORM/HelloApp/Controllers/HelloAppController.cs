using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BusinessLayer.Service;
using ModelLayer.DTO;

namespace HelloApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloAppController : ControllerBase
    {
        private readonly RegisterHelloBL _registerHelloBL;
        private readonly ILogger<HelloAppController> _logger;
        private ResponseModelDTO<string> response;

        public HelloAppController(RegisterHelloBL registerHelloBL, ILogger<HelloAppController> logger)
        {
            _registerHelloBL = registerHelloBL;
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("GET request received in HelloAppController.");
            return _registerHelloBL.registration("Value from controller");
        }

        [HttpPost]
        public IActionResult LoginUser([FromBody] LoginDTO loginDTO)
        {
            _logger.LogInformation("Login attempt for user: {Username}", loginDTO.username);

            response = new ResponseModelDTO<string>();
            bool res = _registerHelloBL.loginUser(loginDTO);

            if (res)
            {
                response.Success = true;
                response.Message = "Data Received Successfully";
                response.Data = loginDTO.username;
                return Ok(response);
            }

            response.Success = false;
            response.Message = "Login Unsuccessful";
            response.Data = "";

            _logger.LogWarning("Login failed for user: {Username}", loginDTO.username);
            return NotFound(response);
        }
    }
}
