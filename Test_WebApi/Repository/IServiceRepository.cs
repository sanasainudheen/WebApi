using System.Collections.Generic;
using System.Threading.Tasks;
using Test_WebApi.Models;

namespace Test_WebApi.Repository
{
    public interface IServiceRepository
    {
        Task<List<ServiceModel>> GetServicesByIdAsync(int categoryId);
    }
}
