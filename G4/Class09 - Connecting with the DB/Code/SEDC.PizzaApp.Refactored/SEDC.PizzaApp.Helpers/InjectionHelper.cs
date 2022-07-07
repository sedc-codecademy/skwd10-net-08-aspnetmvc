using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.DataAccess.EFImplementations;
using SEDC.PizzaApp.DataAccess.Implementations;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Services.Implementations;
using SEDC.PizzaApp.Services.Interfaces;

namespace SEDC.PizzaApp.Helpers
{
    public static class InjectionHelper
    {
        //Via dependency injection we tell the application, wherever you see that a class is dependent on this interface,
        //give it an instance of the following class. For example, if you see that a class is dependent on something of type
        //IOrderService (param in the constructor), give it an instnace of OrderService.

        //This way the classes don't take care of instantiating. It is done on app level.
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<User>, UserRepository>();
            //services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Order>, OrderEFRepository>();
            services.AddTransient<IRepository<Pizza>, PizzaRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPizzaService, PizzaService>();

        }

        public static void InjectDbContext(IServiceCollection services)
        {
            services.AddDbContext<PizzaAppDbContext>(options =>
            {
                //local server (our machine), the database is PizzaAppDb, we use Windows Credentials
                //options.UseSqlServer("Server=.\\sqlexpress;Database=PizzaAppDb;Trusted_Connection=True;");
                options.UseSqlServer("Server=.;Database=PizzaAppDb;Trusted_Connection=True;");
            });
        }
    }
}
