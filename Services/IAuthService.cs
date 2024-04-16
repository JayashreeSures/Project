using Cake_palace.models;

namespace Cake_palace.Services
{
    public interface IAuthService
    {
        Task<string> Authorize(Login user,string userRole);
    }
}
