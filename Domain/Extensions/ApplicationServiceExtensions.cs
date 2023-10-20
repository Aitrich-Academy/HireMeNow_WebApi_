using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HireMeNow_WebApi.Extensions
{
    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            //);
            return services;
        }
    }
}
