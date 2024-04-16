using Cake_palace.models;

namespace Cake_palace.Repository
{
    public interface IUserRepository
    {
        Task<User> Register(User user);
        Task<string> Login(Login user);
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);

        Task<User> DeleteUser(User user);

        Task<User> UpdateUser(int id, User user);


    }
}
