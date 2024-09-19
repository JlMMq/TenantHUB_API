using System.Runtime.CompilerServices;
using Tenant.Core.Interfaces;
using Tenant.Infrastructure.UnitOfWork;

namespace Tenant.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void ConfigurateCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => { 
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
        }
    }
}
