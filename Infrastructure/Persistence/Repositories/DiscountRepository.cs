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
    public class DiscountRepository : IDiscountRepository
    {
        private readonly SignalRContext _context;

        public DiscountRepository(SignalRContext context)
        {
            _context = context;
        }

        public async Task ChangeStatusToFalse(int id)
        {
            var value=await _context.Discounts.FindAsync(id);
            value.Status=false;
            await _context.SaveChangesAsync();
        }

        public async Task ChangeStatusToTrue(int id)
        {
            var value = await _context.Discounts.FindAsync(id);
            value.Status = true;
            await _context.SaveChangesAsync();
        }

		public async Task<List<Discount>> GetListByStatusTrue()
		{
            var values = await _context.Discounts.Where(x => x.Status == true).ToListAsync();
            return values;
		}
	}
}
