using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface IUserRepository
	{
		Task<User> GetByFilterAsync(Expression<Func<User, bool>> filter);
	}
}
