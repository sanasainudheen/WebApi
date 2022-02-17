using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_WebApi.Data;
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
     
        [HttpGet("")]
        [ActionName("FetchOrders")]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var requests = await _serviceRequestRepository.GetAllOrdersAsync();
            return Ok(requests);

            }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicesByReqId([FromRoute] int id)
        {
            var services = await _serviceRequestRepository.GetServicesByReqId(id);
            if (services == null)
            {
                return NotFound();
            }
            return Ok(services);

        }       
        [HttpPost("")]
        public async Task<IActionResult> CreateOrder([FromBody] NewOrderModel newOrderModel)  
        {
            var id = await _serviceRequestRepository.CreateRequestAsync(newOrderModel);
            if (id != 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Something went wrong....");
            }

        }

        [HttpPut("{reqDetId}")]
        public async Task<IActionResult> UpdateServiceAsync([FromBody] OrderDetails orderDetails, [FromRoute] int reqDetId)
        {
            var id = await _serviceRequestRepository.UpdateServiceAsync(orderDetails, reqDetId);
             return Ok();

        }
       
        [HttpPut("UpdateOrderAsync/{orderId}")]
        public async Task<IActionResult> UpdateOrderAsync([FromBody] Order order, [FromRoute] int orderId)
        {
            var id = await _serviceRequestRepository.UpdateOrderAsync(order, orderId);
            return Ok();

        }
        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrderAsync([FromRoute] int orderId)
        {
            await _serviceRequestRepository.DeleteOrderAsync(orderId);
            return Ok();

        }



    }
}
