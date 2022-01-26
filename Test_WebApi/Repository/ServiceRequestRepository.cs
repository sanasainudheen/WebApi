using System.Collections.Generic;
using System.Threading.Tasks;
using Test_WebApi.Context;
using Test_WebApi.Data;
using Test_WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Test_WebApi.Repository
{
    public class ServiceRequestRepository:IServiceRequestRepository
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
        public async Task<List<RequestDataModel>> GetAllServiceRequestsAsync()
        {
            var records =await _context.RequestData.FromSqlRaw("SP_GetServiceRequests").ToListAsync();
            return records;
        }
        public async Task<int> CreateServiceRequestAsync(CreateRequestModel createRequestModel)
        {
            var createRequest = new CreateRequest
            {
                categoryId = createRequestModel.categoryId,
                serviceId = createRequestModel.serviceId,
                userId = createRequestModel.userId,
                modeOfPay= createRequestModel.modeOfPay,
                startDate = createRequestModel.startDate,
                endDate = createRequestModel.endDate

            };
            _context.CreateRequest.Add(createRequest);
            await _context.SaveChangesAsync();
            return createRequest.Id;
        }
    }
}
