

using ModelLayer.DTO;

namespace BusinessLayer.Interface
{
    public  interface IRegistrationHelloBL
    {
        string registration(string name);
        bool loginUser(LoginDTO loginDTO);
    }
}
