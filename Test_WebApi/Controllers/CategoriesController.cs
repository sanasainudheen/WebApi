using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Test_WebApi.Repository;

namespace Test_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository CategoryRepository)
        {
            _categoryRepository = CategoryRepository;


        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return Ok(categories);

        }
    }
}
