using Application.Features.Mediatr.Baskets.Commands;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class BasketRepository:IBasketRepository
    {
        private readonly SignalRContext _context;

        public BasketRepository(SignalRContext context)
        {
            _context = context;
        }

        public async Task CreateBasket(CreateBasketCommand command)
        {

            await _context.Baskets.AddAsync(new Basket
            {
                ProductId=command.ProductId,
                Count=1,
                TableId=1,
                Price=await _context.Products.Where(x=>x.ProductId==command.ProductId).Select(y=>y.Price).FirstOrDefaultAsync(),
                TotalPrice=0,
            });;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Basket>> GetBasketByTableNumber(int id)
        {
            var values=await _context.Baskets
                .Include(x=>x.Product)
                .Where(x=>x.TableId==id).ToListAsync();
            return values;

        }
    }
}
