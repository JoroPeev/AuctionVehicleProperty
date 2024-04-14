using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Services;
using AuctionVehicleProperty.Infrastructure.Data;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services) 
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<IAuctionService, AuctionService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
        public static IServiceCollection AddAplicationDbContext(this IServiceCollection services,IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
        public static IServiceCollection AddAplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<AppUser>(options =>
            {
                options.User.RequireUniqueEmail= true;
                options.SignIn.RequireConfirmedAccount = false;

            }).AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }

    }
}
