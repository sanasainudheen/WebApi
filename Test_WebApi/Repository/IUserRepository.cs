using System.Collections.Generic;
using System.Threading.Tasks;
using Test_WebApi.Models;

namespace Test_WebApi.Repository
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsersAsync();

        Task<UserModel> GetUserByIdAsync(int userId);
        Task<int> AddUserAsync(UserModel userModel);

        Task<int> UpdateUserAsync(int userId, UserModel userModal);

        Task DeleteUserAsync(int userID);
    }
}
