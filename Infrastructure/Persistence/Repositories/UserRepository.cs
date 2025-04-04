using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly SignalRContext _context;

		public UserRepository(SignalRContext context)
		{
			_context = context;
		}

		public async Task<User> GetByFilterAsync(Expression<Func<User, bool>> filter)
		{
			var user = await _context.Users.Where(filter)
			   .FirstOrDefaultAsync();
			return user;
		}
	}
}
