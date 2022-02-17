using System.Collections.Generic;
using System.Threading.Tasks;
using Test_WebApi.Context;
using Test_WebApi.Data;
using Test_WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Http.Headers;
using Microsoft.Data.SqlClient;

namespace Test_WebApi.Repository
{
    public class ServiceRequestRepository : IServiceRequestRepository
    {
        private readonly AppDbContext _context;

        public ServiceRequestRepository(AppDbContext context)
        {
            _context = context;
        }
        //public async Task<int> AddServiceRequestAsync(RequestModel requestModel)
        //{
        //    var request = new Request
        //    {
        //        categoryId = requestModel.categoryId,
        //        serviceId = requestModel.serviceId,
        //        userId = requestModel.userId,

        //    };
        //    _context.Requests.Add(request);
        //    await _context.SaveChangesAsync();
        //    return request.Id;
        //}
        public async Task<List<FetchOrdersModel>> GetAllOrdersAsync()
        {
            var records = await _context.OrdersData.FromSqlRaw("SP_GetServiceRequests").ToListAsync();
            return records;
        }
        public async Task<List<FetchServicesModel>> GetServicesByReqId(int orderId)
        {
            //var services = await _context.ServicesData.Where(x => x.ReqId == orderId).FromSqlRaw("SP_GetServiceRequests").ToListAsync();
            //return services;
            SqlParameter orderRequestId = new SqlParameter("@OrderRequestId", orderId);
            var records = await _context.ServicesData.FromSqlRaw("EXECUTE SP_GetServicesByReqId @OrderRequestId", orderRequestId).ToListAsync();
            return records;
        }
        public async Task<int> CreateServiceRequestAsync(CreateRequestModel createRequestModel)
        {
            var createRequest = new CreateRequest
            {
                categoryId = createRequestModel.categoryId,
                serviceId = createRequestModel.serviceId,
                userId = createRequestModel.userId,
                modeOfPay = createRequestModel.modeOfPay,
                startDate = createRequestModel.startDate,
                endDate = createRequestModel.endDate

            };
            _context.CreateRequest.Add(createRequest);
            await _context.SaveChangesAsync();
            return createRequest.Id;
        }

       
        public async Task<int> CreateRequestAsync(NewOrderModel newOrderModel)
        {
            int count = 0;
            var order = new Order
            {
                UserId = newOrderModel.UserId,
                PayMode = newOrderModel.PayMode,
                Status=newOrderModel.Status,
                MainDocFileName = newOrderModel.MainDocFileName            

            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            var orderId = order.ReqId;

            if (orderId > 0)
            {
                for (int i = 0; i < newOrderModel.Items.Count; i++)
                {
                    var orderDetails = new OrderDetails
                    {
                        ReqId = orderId,
                        CategoryId = newOrderModel.Items[i].CategoryId,
                        ServiceId = newOrderModel.Items[i].ServiceId,
                        StartDate = newOrderModel.Items[i].StartDate,
                        EndDate = newOrderModel.Items[i].EndDate,
                        DocumentFileName= newOrderModel.Items[i].DocFileName,
                        //  Document = newOrderModel.Items[i].Document
                    };
                    count++;
                    _context.OrderDetails.Add(orderDetails);
                    await _context.SaveChangesAsync();
                }
            }
            if (count > 0) return 1;
            else return 0;
        }
      
        public async Task<int> UpdateServiceAsync(OrderDetails orderDetailsObj, int reqDetId)
        {
            var service = await _context.OrderDetails.FindAsync(reqDetId);
            if (service != null)
            {

                service.CategoryId = orderDetailsObj.CategoryId;
                service.ServiceId = orderDetailsObj.ServiceId;
                service.StartDate = orderDetailsObj.StartDate;
                service.EndDate = orderDetailsObj.EndDate;

                await _context.SaveChangesAsync();
            }
            return service.ReqDetId;
        }
        public async Task<int> UpdateOrderAsync(Order order, int orderId)
        {
            var orderItem = await _context.Orders.FindAsync(orderId);
            if (orderItem != null)
            {

                orderItem.ReqId = order.ReqId;
                orderItem.UserId = order.UserId; 
                orderItem.PayMode = order.PayMode;
                orderItem.Status = order.Status;
                orderItem.MainDocFileName = order.MainDocFileName;

                await _context.SaveChangesAsync();
            }
            return orderItem.ReqId;
        }
        public async Task DeleteOrderAsync(int orderId)
        {
            var order = new Order() { ReqId = orderId };
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

        }

    }
}
           
   
