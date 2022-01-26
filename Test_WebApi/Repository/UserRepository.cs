using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_WebApi.Context;
using Test_WebApi.Data;
using Test_WebApi.Models;

namespace Test_WebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var records = await _context.Users.Select(x => new UserModel()
            {
                Id = x.Id,
                name = x.name,
                emailId = x.emailId,
                userName = x.userName,
                password = x.password
            }).ToListAsync();
            return records;
        }
        public async Task<UserModel> GetUserByIdAsync(int userId)
        {
            var records = await _context.Users.Where(x => x.Id == userId).Select(x => new UserModel()
            {
                Id = x.Id,
                name = x.name,
                emailId = x.emailId,
                userName = x.userName,
                password = x.password
            }).FirstOrDefaultAsync();
            return records;
        }
        public async Task<int> AddUserAsync(UserModel userModel)
        {
            var user = new User
            {
                name = userModel.name,
                emailId = userModel.emailId,
                userName = userModel.userName,
                password = userModel.password
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
        public async Task<int> UpdateUserAsync(int userId, UserModel userModal)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                user.name = userModal.name;
                user.emailId = userModal.emailId;
                user.userName = userModal.userName;
                user.password = userModal.password;
                await _context.SaveChangesAsync();
            }
            return userId;
        }
        public async Task DeleteUserAsync(int userID)
        {
            var user = new User() { Id = userID };
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

        }
    }
}
