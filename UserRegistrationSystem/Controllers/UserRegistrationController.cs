using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Services;
using RepositoryLayer.Service;
using ModelLayer.DTO;

namespace UserRegistration.Controllers;

[ApiController]
[Route("[controller]")]
public class UserRegistrationController : ControllerBase
{
    UserRegistrationBL _userRegistrationBL;
    ResponseBody<string> response;
    public UserRegistrationController(UserRegistrationBL userRegistrationBL)
    {
        _userRegistrationBL = userRegistrationBL;

    }
    [HttpGet]
    public string Get()
    {
        return "Hello!\n Register using Post Request...";
    }

    [HttpPost]
    public List<User> Registration(User user)
    {
        List<User> result = _userRegistrationBL.RegistrationBL(user);

        return result;


    }

}