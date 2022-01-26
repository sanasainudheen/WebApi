using System.Collections.Generic;
using System.Threading.Tasks;
using Test_WebApi.Models;

namespace Test_WebApi.Repository
{
    public interface IServiceRequestRepository
    {
        //Task<int> AddServiceRequestAsync(RequestModel requestModel);
        Task<List<RequestDataModel>> GetAllServiceRequestsAsync();

        Task<int> CreateServiceRequestAsync(CreateRequestModel createRequestModel);
    }
}
