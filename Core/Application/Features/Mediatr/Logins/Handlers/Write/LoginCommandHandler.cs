//using Application.Features.Mediatr.Logins.Commands;
//using Domain;
//using MediatR;
//using Microsoft.AspNetCore.Identity;

//public class LoginCommandHandler : IRequestHandler<LoginCommand, ResultDto>
//{
//	private readonly SignInManager<AppUser> _signInManager;
//	private readonly UserManager<AppUser> _userManager;

//	public LoginCommandHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
//	{
//		_signInManager = signInManager;
//		_userManager = userManager;
//	}

//	public async Task<ResultDto> Handle(LoginCommand request, CancellationToken cancellationToken)
//	{
//		var user = await _userManager.FindByNameAsync(request.Username);
//		if (user == null)
//			return new ResultDto(false, "Kullanıcı bulunamadı");

//		var result = await _signInManager.PasswordSignInAsync(user, request.Password, true, false);
//		if (result.Succeeded)
//		{
//			await _signInManager.SignInAsync(user, true); // <--- Cookie'yi manuel olarak oluştur
//			return new ResultDto(true, "Giriş başarılı");
//		}
//		if (!result.Succeeded)
//			return new ResultDto(false, "Giriş başarısız");

//		return new ResultDto(true, "Giriş başarılı");
//	}
//}

using Application.Features.Mediatr.Logins.Commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

public class LoginCommandHandler : IRequestHandler<LoginCommand, ResultDto>
{
	private readonly SignInManager<AppUser> _signInManager;
	private readonly UserManager<AppUser> _userManager;
	private readonly IHttpContextAccessor _httpContextAccessor;

	public LoginCommandHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
	{
		_signInManager = signInManager;
		_userManager = userManager;
		_httpContextAccessor = httpContextAccessor;
	}

	public async Task<ResultDto> Handle(LoginCommand request, CancellationToken cancellationToken)
	{
		var user = await _userManager.FindByNameAsync(request.Username);
		if (user == null)
			return new ResultDto(false, "Kullanıcı bulunamadı");

		var result = await _signInManager.PasswordSignInAsync(user, request.Password, true, false);
		if (!result.Succeeded)
			return new ResultDto(false, "Giriş başarısız");

		// Kullanıcı için kimlik doğrulama çerezi (cookie) oluştur
		var claims = new List<Claim>
		{
			new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new Claim(ClaimTypes.Name, user.UserName),
		};

		var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
		var authProperties = new AuthenticationProperties
		{
			IsPersistent = true, // Tarayıcı kapansa bile oturum açık kalsın
			ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1) // 1 saat geçerli
		};

		var httpContext = _httpContextAccessor.HttpContext;
		if (httpContext != null)
		{
			await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
		}

		return new ResultDto(true, "Giriş başarılı, cookie oluşturuldu.");
	}
}


