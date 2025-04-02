using Application.Features.Mediatr.Registers.Commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Registers.Handlers.Write
{
	public class CreateRegisterCommandHandler : IRequestHandler<CreateRegisterCommand>
	{
		private readonly UserManager<AppUser> _userManager;

		public CreateRegisterCommandHandler(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task Handle(CreateRegisterCommand request, CancellationToken cancellationToken)
		{
			var appUser = new AppUser()
			{
				Name = request.Name,
				Surname = request.Surname,
				Email = request.Mail,
				UserName = request.Username,
			};
			await _userManager.CreateAsync(appUser, request.Password);

		}
	}
}
