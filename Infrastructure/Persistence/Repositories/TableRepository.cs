using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly SignalRContext _context;

        public TableRepository(SignalRContext context)
        {
            _context = context;
        }

        public async Task<int> GetTableCount()
        {
            return await _context.MenuTables.CountAsync();
        }
    }
}
