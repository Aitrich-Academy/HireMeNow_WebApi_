using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HireMeNow_WebApi.Extensions
{
    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DbHireMeNowWebApiContext>(options =>
               options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
            return services;
        }
    }
}
