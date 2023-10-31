using Domain;

using Microsoft.EntityFrameworkCore;
using Domain.Service;
using MailKit;
using Domain.Service.Authuser.Interfaces;
using Domain.Service.Authuser;
using Domain.Service.SignUp.Interfaces;
using Domain.Service.SignUp;
using Domain.Models;

using Domain.Service.Job.Interfaces;
using Domain.Service.Job;
using Domain.Service.JobProvider.Interfaces;
using Domain.Service.JobProvider;

using Domain.Service.Login.Interfaces;
using Domain.Service.Login;
using Domain.Service.Job;
using Domain.Service.Job.Interfaces;
using Domain.Service.JobProvider.Interfaces;
using Domain.Service.JobProvider;
using Domain.Service.Profile;
using Domain.Service.JobSeeker.Interfaces;
using Domain.Service.Profile.Interface;

namespace HireMeNow_WebApi.Extensions
{
    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DbHireMeNowWebApiContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<ILoginRequestService, LoginRequestService>();
            services.AddScoped<ILoginRequestRepository, LoginRequestRepository>();
            services.AddScoped<ISignUpRequestRepository, SignUpRequestRepository>();
            services.AddScoped<ISignUpRequestService, SignUpRequestService>();
            services.AddScoped<IAuthUserRepository, AuthUserRepository>();


            services.AddScoped<IJobProviderService, JobProviderService>();
            services.AddScoped<IJobProviderRepository, JobProviderRepository>();

			services.AddScoped<IJobRepository, JobRepository>();
			services.AddScoped<IJobServices, JobServices>();
			services.AddScoped<IAuthUserService, AuthUserService>();

            services.AddScoped<IJobSeekerProfileService, ProfileService>();
          
            services.AddScoped<IJobSeekerProfileRepository, ProfileRepository>();

            services.AddScoped<ICompanyRepository, Companyrepository>();
            services.AddScoped<ICompanyService,Companyservice>();   


            return services;
        }
    }
}
