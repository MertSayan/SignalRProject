using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace SignalRWebUI
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Tüm controller'larda kullanıcı giriş yapmış olmalı
            var requireAuthorizePolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            builder.Services.AddControllersWithViews(opt =>
            {
                opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
            });
            builder.Services.AddHttpClient();
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			   .AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
			   {
				   opt.LoginPath = "/Login/Index/";
				   opt.LogoutPath = "/login/LogOut";
				   opt.AccessDeniedPath = "/Pages/AccessDenied/"; // bu sayfayı olusturup tasarlıcaksın daha.
				   opt.Cookie.SameSite = SameSiteMode.Strict;
				   opt.Cookie.HttpOnly = true;
				   opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
				   opt.Cookie.Name = "SignalRRestorantJwt";
			   });








            var app = builder.Build();

            // Hata sayfalarını yönetme
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Middleware sırasını düzelttim
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Kullanıcı kimlik doğrulaması middleware'i
            app.UseAuthorization();  // Yetkilendirme middleware'i

            // Endpoint tanımları **UseRouting()'ten sonra olmalı**
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}

