using System.Collections.Generic;
using System.Threading.Tasks;
using Test_WebApi.Data;
using Test_WebApi.Models;

namespace Test_WebApi.Repository
{
    public interface IServiceRequestRepository
    {      
       Task<List<FetchOrdersModel>> GetAllOrdersAsync();
        Task<List<FetchServicesModel>> GetServicesByReqId(int orderId);
        Task<int> CreateRequestAsync(NewOrderModel newOrderModel);
        Task<int> UpdateServiceAsync(OrderDetails orderDetails,int reqDetId);
        Task<int> UpdateOrderAsync(Order order, int orderId);
        Task DeleteOrderAsync(int orderId);


    }
}
