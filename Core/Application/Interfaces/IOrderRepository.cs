using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> GetTotalOrderCount();
        Task<int> GetActiveOrderCount();
        Task<decimal> GetLastOrderPrice();
        Task<decimal> GetTodayTotalPrice();
    }
}
