using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_WebApi.Context;
using Test_WebApi.Models;

namespace Test_WebApi.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryModel>> GetAllCategoriesAsync()
        {
            var records = await _context.Categories.Select(x => new CategoryModel()
            {
                Id = x.Id,
                categoryName = x.categoryName,
               
            }).ToListAsync();
            return records;
        }
    }
}
