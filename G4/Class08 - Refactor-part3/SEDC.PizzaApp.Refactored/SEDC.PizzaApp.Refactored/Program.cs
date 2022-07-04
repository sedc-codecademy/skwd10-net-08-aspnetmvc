using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.DataAccess.Implementations;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Helpers;
using SEDC.PizzaApp.Services.Implementations;
using SEDC.PizzaApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//INJECT SERVICES
//builder.Services.AddTransient<IOrderService, OrderService>();
//builder.Services.AddTransient<IUserService, UserService>();
InjectionHelper.InjectServices(builder.Services);

//INJECT REPOSITORIES
//builder.Services.AddTransient<IRepository<User>, UserRepository>();
//builder.Services.AddTransient<IRepository<Order>, OrderRepository>();
InjectionHelper.InjectRepositories(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
