using DataAcces.Interfaces;
using DataAccess;
using Logic;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ServerFactory
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services,string connectionString)
        {
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<DbContext, Context>(o => o.UseSqlServer(connectionString));
            return services;
        }
    }
}