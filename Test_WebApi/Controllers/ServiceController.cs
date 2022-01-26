using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_WebApi.Repository;

namespace Test_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;

        }
      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicesByIdAsync([FromRoute] int id)
        {
            var service = await _serviceRepository.GetServicesByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);

        }
    }
}
