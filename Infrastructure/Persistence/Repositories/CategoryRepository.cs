using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SignalRContext _context;

        public CategoryRepository(SignalRContext context)
        {
            _context = context;
        }

        public async Task<int> GetActiveCategoryCount()
        {
            return await _context.Categories.Where(x=>x.CategoryStatus==true).CountAsync();
        }

        public async Task<int> GetCategoryCount()
        {
            return await _context.Categories.CountAsync();
        }

        public async Task<int> GetPassiveCategoryCount()
        {
            return await _context.Categories.Where(x => x.CategoryStatus == false).CountAsync();
        }
    }
}
