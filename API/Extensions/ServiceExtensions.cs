using BL.Abstractions.Implementations;
using BL.Abstractions.Interfaces;
using BL.Services;
using DL;
using DL.Entities;
using DL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ServicesRegistry(this IServiceCollection services, IConfiguration configuration)
        {
            services.Repositories(configuration);
            services.Services(configuration);
            services.Database(configuration);
            services.Misc(configuration);
        }

        public static void Repositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
        }

        public static void Misc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

        public static void Services(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFileService, FileService>();
            services.AddMemoryCache();
            services.AddScoped<ICacheService, CacheService>();
        }
        
        public static void Database(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ApplicationDBContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("cs")));
        }


    }
}
