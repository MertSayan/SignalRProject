using Application.Features.Mediatr.Logins.Commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Logins.Handlers.Write
{
	public class CreateLoginCommandHandler : IRequestHandler<CreateLoginCommand>
	{
		private readonly SignInManager<AppUser> _signInManager;

		public CreateLoginCommandHandler(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		public async Task Handle(CreateLoginCommand request, CancellationToken cancellationToken)
		{
			var value=await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
			if (value.Succeeded)
			{
				
			}
			//lockoutonfail ( son parametre yukarıdaki ) false yaptım bu, appnetusers tablosunda bir sütun var her yanlış
			//şifre girdiğinde bir artıyor belli bir sayıya ulaşınca seni sistemden bir süre banlıyor 
			//bu olmasın şimdilik diye false yaptım.
		}
	}
}
