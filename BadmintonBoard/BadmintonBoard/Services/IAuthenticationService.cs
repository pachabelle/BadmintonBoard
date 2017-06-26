using System.Threading.Tasks;

namespace BadmintonBoard.Services
{
    public interface IAuthenticationService
    {
        Task<bool> SignInAsync();
        Task<bool> SignOutAsync();
    }
}
