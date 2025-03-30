using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class MoneyCaseRepository : IMoneyCaseRepository
    {
        private readonly SignalRContext _context;

        public MoneyCaseRepository(SignalRContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetTotalMoneyCaseAmount()
        {
            return await _context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefaultAsync();
        }
    }
}
