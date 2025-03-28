using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Servicess
{
    public static class ServiceRegistration
    {
        public static void AddSaveApplicationService(this IServiceCollection services,
            IConfiguration configuratiın)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
            services.AddAutoMapper(typeof(ServiceRegistration).Assembly); // AutoMapper Profillerini yükler

        }
    }
}
