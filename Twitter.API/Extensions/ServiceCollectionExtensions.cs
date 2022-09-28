

using Twitter.Domain.Repositories;
using Twitter.Domain.Services;
using Twitter.Infrastructure.Auth;
using Twitter.Infrastructure.Persistance.Repositories;

namespace Twitter.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITweetRepository, TweetRepository>();
            services.AddScoped<IFollowRepository, FollowRepository>();

            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
