using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_WebApi.Context;
using Test_WebApi.Models;

namespace Test_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }
        //[HttpPost("")]
        //public async Task<IActionResult<EmployeeModel>> AddUserAsync([FromBody] EmployeeModel employeeModel)
        //{
        //    _context.Employees.Add(employeeModel);
        //   await _context.SaveChangesAsync();
        //    return 


        //}
    }
}
