using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cake_palace.Data;
using Cake_palace.models;
using Cake_palace.Services;

namespace Cake_palace.Repository
{
    public class UserRepository : IUserRepository
    {
        
        private readonly Cake_palaceContext _context;
        public readonly IAuthService _auth;
        public UserRepository(IAuthService auth, Cake_palaceContext context)
        {
            _auth = auth;
            _context = context;

        }







        public async Task<User> Register(User user)
        {
            
            var UserExists =   _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (UserExists != null)
            {
                return UserExists;
            }
            else
            {
            _context.Users.Add(user);
            _context.SaveChanges();
            return UserExists;
            }
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<string> Login(Login user)
        {
            var userLogin = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email &&  u.Password == user.Password);
            if (userLogin == null)
            {
                return "null";
            }
            var jwt = await _auth.Authorize(user, userLogin.Role);
            return jwt;

        }

        public async Task<User> DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            var us = await _context.Users.FindAsync(id);
            if(us == null)
            {
                return us;
            }
            else
            {
                us.Name = user.Name;
                us.PostelCode = user.PostelCode;
                us.Address = user.Address;
                us.MobileNo = user.MobileNo;
                await _context.SaveChangesAsync();
                return us;

            }
        }
    }
}
