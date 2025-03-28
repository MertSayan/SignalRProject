using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var values=await _context.Products
                .Include(x=>x.Category)
                .ToListAsync();
            return values;
        }
    }
}
