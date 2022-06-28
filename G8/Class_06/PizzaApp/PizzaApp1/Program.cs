using PizzaApp.Application.Repository;
using PizzaApp.Application.Services;
using PizzaApp.Application.Services.Implementation;
using PizzaApp.Domain.Models;
using PizzaApp.StaticDb.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc().AddNewtonsoftJson();
builder.Services.AddSingleton<IRepository<Order>, OrderRepository>();
builder.Services.AddSingleton<IRepository<Pizza>, PizzaRepository>();
//builder.Services.AddSingleton<IRepository<Order>, OrderEFRepository>();

builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddSingleton<IPizzaService, PizzaService>();

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


// Convetional dedicated route
//blog/
//blog/article
//blog/asdasdasdasd
//blog/how-to-code
app.MapControllerRoute(
        name: "blog",
        pattern: "blog/{*article}/",
        defaults: new { controller = "Blog", action = "BlogArticle" }
    );
// www.nasa-aplikacija/home/privacy
//home/index/1asdads
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pizza}/{action=Index}/{id:int?}");

//app.MapControllerRoute(
//    name: "newpattern",
//    pattern: "{controller=Home}/{action=Index}/{article}",
//    defaults: new { controller = "Blog", action = "BlogArticle" });


app.Run();
