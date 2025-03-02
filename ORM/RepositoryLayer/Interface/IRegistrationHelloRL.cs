

using ModelLayer.DTO;

namespace RepositoryLayer.Interface
{
    public interface IRegistrationHelloRL
    {
        string GetHello(string name);
        LoginDTO getUsernamePassword(LoginDTO loginDTO);
        LoginDTO Database(LoginDTO loginDTO);
    }
}
