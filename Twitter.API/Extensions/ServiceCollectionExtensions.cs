

using Twitter.Domain.Repositories;
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

            return services;
        }
    }
}
