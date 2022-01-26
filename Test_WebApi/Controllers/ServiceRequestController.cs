using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_WebApi.Models;
using Test_WebApi.Repository;

namespace Test_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRequestRepository _serviceRequestRepository;
        public ServiceRequestController(IServiceRequestRepository serviceRequestRepository)
        {
            _serviceRequestRepository = serviceRequestRepository;


        }
        //[HttpPost("")]
        //public async Task<int> AddServiceRequestAsync([FromBody] RequestModel requestModel)
        //{
        //    var id = await _serviceRequestRepository.AddServiceRequestAsync(requestModel);
        //    return id;

        //}
        [HttpGet("")]
        public async Task<IActionResult> GetAllServiceRequestsAsync()
        {
            var requests = await _serviceRequestRepository.GetAllServiceRequestsAsync();
            return Ok(requests);

        }
        [HttpPost("")]
        public async Task<int> CreateServiceRequestAsync([FromBody] CreateRequestModel createRequestModel)
        {
            var id = await _serviceRequestRepository.CreateServiceRequestAsync(createRequestModel);
            return id;

        }
    }
}
