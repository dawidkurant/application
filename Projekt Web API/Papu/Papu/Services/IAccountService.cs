using Papu.Models;

namespace Papu.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
    }
}
