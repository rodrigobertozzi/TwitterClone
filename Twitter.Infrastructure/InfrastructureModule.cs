using System.Text;
using Twitter.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Twitter.Infrastructure.Persistance;
using Twitter.Infrastructure.Persistance.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Twitter.Domain.Services;
using Twitter.Infrastructure.Auth;

namespace Twitter.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            services
                .AddPersistence(configuration)
                .AddRepositories()
                .AddUnitOfWork()
                .AddAuthentication(configuration);
                //.AddMessageBus()
                //.AddServices();

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("TwitterCs");

            services.AddDbContext<TwitterDbContext>(options => options.UseSqlServer(connectionString));
            // services.AddDbContext<TwitterDbContext>(options => options.UseInMemoryDatabase("TwitterDb"));

            return services;
        }
        private static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddScoped<ITweetRepository, TweetRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFollowRepository, FollowRepository>();

            return services;
        }

        private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };
                });

            services.AddScoped<IAuthService, AuthService>();

            return services;
        }

        //private static IServiceCollection AddMessageBus(this IServiceCollection services) {
        //    services.AddScoped<IMessageBusService, MessageBusService>();

        //    return services;
        //}

        //private static IServiceCollection AddServices(this IServiceCollection services) {
        //    services.AddScoped<IPaymentService, PaymentService>();

        //    return services;
        //}

        private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

    }
}