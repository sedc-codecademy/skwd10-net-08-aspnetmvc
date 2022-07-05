using PizzAppOnion.Contracts.Services;
using PizzAppOnion.Domain.Repositories;
using PizzAppOnion.Services;
using PizzAppOnion.Storage.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IOrderService, OrderService>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<IPizzaService, PizzaService>()
                .AddScoped<IPizzaRepository, PizzaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
