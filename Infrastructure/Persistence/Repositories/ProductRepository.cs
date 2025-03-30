using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SignalRContext _context;

        public ProductRepository(SignalRContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductWithCategories()
        {
            var values = await _context.Products
                .Include(x => x.Category)
                .ToListAsync();
            return values;
        }

        public async Task<string> GetProductByMaxPrice()
        {
            return await _context.Products.Where(x => x.Price == (_context.Products.Max(y => y.Price)))
                .Select(z => z.ProductName).FirstOrDefaultAsync();
        }

        public async Task<string> GetProductByMinPrice()
        {
            return await _context.Products.Where(x => x.Price == (_context.Products.Min(y => y.Price)))
                .Select(z => z.ProductName).FirstOrDefaultAsync();
        }

        public async Task<int> GetProductCount()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<int> GetProductCountByCategoryName(string categoryName)
        {
            return await _context.Products.Where(x => x.CategoryId == (_context.Categories.Where(
                y => y.CategoryName == categoryName).Select(z => z.CategoryId).FirstOrDefault())).CountAsync();
        }

        public async Task<decimal> GetProductPriceAvg()
        {
            return await _context.Products.AverageAsync(x => x.Price);
        }

        public async Task<decimal> GetProductPriceAvgByCategoryName(string categoryName)
        {
            return await _context.Products.Where(x => x.Category.CategoryName == categoryName).Select(y => y.Price).AverageAsync();
        }
    }
}
