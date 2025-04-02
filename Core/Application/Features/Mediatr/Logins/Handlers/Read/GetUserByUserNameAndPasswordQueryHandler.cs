using Application.Features.Mediatr.Logins.Queries;
using Application.Features.Mediatr.Logins.Results;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Mediatr.Logins.Handlers.Read
{
	public class GetUserByUserNameAndPasswordQueryHandler : IRequestHandler<GetUserByUserNameAndPasswordQuery, GetUserByUserNameAndPasswordQueryResult>
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;
		public GetUserByUserNameAndPasswordQueryHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}
		public async Task<GetUserByUserNameAndPasswordQueryResult> Handle(GetUserByUserNameAndPasswordQuery request, CancellationToken cancellationToken)
		{
			var signInResult = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
			//lockoutonfail ( son parametre yukarıdaki ) false yaptım bu, appnetusers tablosunda bir sütun var her yanlış
			//şifre girdiğinde bir artıyor belli bir sayıya ulaşınca seni sistemden bir süre banlıyor 
			//bu olmasın şimdilik diye false yaptım.

			if (signInResult.Succeeded)
			{
				var user = await _userManager.FindByNameAsync(request.UserName);
				if (user == null)
				{
					return null; // Kullanıcı bulunamazsa null dönebiliriz.
				}

				return new GetUserByUserNameAndPasswordQueryResult
				{
					Mail=user.Email,
					Name=user.Name,
					Password=user.PasswordHash,
					Surname=user.Surname,
					Username = user.UserName
				};
			}

			return null; // Giriş başarısızsa null döndürüyoruz.
						
			
		}
	}
}
