using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test_WebApi.Context;
using Test_WebApi.Models;

namespace Test_WebApi.Repository
{
    public class ServiceRepository:IServiceRepository
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ServiceModel>> GetServicesByIdAsync(int categoryId)
        {
            var records = await _context.Services.Where(x => x.categoryId == categoryId).Select(x => new ServiceModel()
            {
                Id = x.Id,
                serviceName = x.serviceName,
                categoryId=x.categoryId,
            }).ToListAsync();


          
            return records;
        }
    }
}
