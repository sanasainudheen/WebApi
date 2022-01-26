using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Test_WebApi.Models;
using Test_WebApi.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Test_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;  
        public UsersController(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
            

        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }
        [HttpPost("")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserModel userModel)
        {
            var id = await _userRepository.AddUserAsync(userModel);
            return CreatedAtAction(nameof(GetUserById), new { id = id, controller = "Users" }, id);

        }
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserModel userModel, [FromRoute] int userId)
        {
            var id = await _userRepository.UpdateUserAsync(userId, userModel);
            return CreatedAtAction(nameof(GetUserById), new { id = id, controller = "Users" }, id);

        }
        [HttpDelete("{userid}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
            return Ok();

        }
        
    }
}
