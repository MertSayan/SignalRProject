﻿using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SignalRContext _context;

        public OrderRepository(SignalRContext context)
        {
            _context = context;
        }

        public async Task<int> GetActiveOrderCount()
        {
            return  await _context.Orders.Where(x=>x.Description=="Müşteri Masada").CountAsync();
        }

        public async Task<int> GetTotalOrderCount()
        {
            return await _context.Orders.CountAsync();
        }

        public async Task<decimal> GetLastOrderPrice()
        {
            return await _context.Orders.OrderByDescending(x=>x.OrderId).Take(1).Select(y=>y.TotalPrice).FirstOrDefaultAsync();
        }

        public async Task<decimal> GetTodayTotalPrice()
        {
            //return await _context.Orders.Where(x => x.Date == DateTime.Parse(DateTime.Now.ToShortDateString())).SumAsync(y => y.TotalPrice);
            return 0;
        }
    }
}
