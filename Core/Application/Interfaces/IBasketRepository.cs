using Application.Features.Mediatr.Baskets.Commands;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBasketRepository
    {
        Task<List<Basket>> GetBasketByTableNumber(int id);

        Task CreateBasket(CreateBasketCommand command);
    }
}
