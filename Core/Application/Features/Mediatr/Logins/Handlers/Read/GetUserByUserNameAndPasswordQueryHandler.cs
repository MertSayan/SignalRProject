using Application.Features.Mediatr.Logins.Queries;
using Application.Features.Mediatr.Logins.Results;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Mediatr.Logins.Handlers.Read
{
	public class GetUserByUserNameAndPasswordQueryHandler : IRequestHandler<GetUserByUserNameAndPasswordQuery, GetUserByUserNameAndPasswordQueryResult>
	{
		private readonly IUserRepository _userRepository;

		public GetUserByUserNameAndPasswordQueryHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<GetUserByUserNameAndPasswordQueryResult> Handle(GetUserByUserNameAndPasswordQuery request, CancellationToken cancellationToken)
		{
			var user=await _userRepository.GetByFilterAsync(x=>x.UserName==request.UserName && x.Password==request.Password);

			if (user != null)
			{
				return new GetUserByUserNameAndPasswordQueryResult
				{
					IsExist = true,
					UserId = user.UserId,
					RoleName = user.Role
				};
			}
			else
				return null;
		}
	}
}
