using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.PizzaApp.DataAccess.Data;
using SEDC.PizzaApp.DataAccess.Repositories;
using SEDC.PizzaApp.DataAccess.Repositories.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Services.Services;
using SEDC.PizzaApp.Services.Services.Interfaces;

namespace SEDC.PizzaApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IPizzaService, PizzaService>();
            services.AddTransient<IUserService, UserService>();
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
        }

        public static void InjectDbContext(this IServiceCollection services, string connString)
        {
            services.AddDbContext<PizzaAppDbContext>(options =>
                options.UseSqlServer(connString));
        }
    }
}
