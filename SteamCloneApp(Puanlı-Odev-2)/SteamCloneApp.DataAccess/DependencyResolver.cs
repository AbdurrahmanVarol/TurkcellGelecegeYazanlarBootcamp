using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SteamCloneApp.DataAccess.Repositories;
using SteamCloneApp.DataAccess.Repositories.EntityFramework;
using SteamCloneApp.DataAccess.Repositories.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.DataAccess
{
    public static class DependencyResolver
    {
        public static void LoadDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<SteamCloneContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });

            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<IGameRepository, EfGameRepository>();
            services.AddScoped<IGenreRepository, EfGenreRepository>();
            services.AddScoped<IRoleRepository, EfRoleRepository>();
            services.AddScoped<IDeveloperRepository, EfDeveloperRepository>();
            services.AddScoped<IPublisherRepository, EfPublisherRepository>();
            services.AddScoped<IReviewRepository, EfReviewRepository>();
            services.AddScoped<IImageRepository, EfImageRepository>();
        }
    }
}
