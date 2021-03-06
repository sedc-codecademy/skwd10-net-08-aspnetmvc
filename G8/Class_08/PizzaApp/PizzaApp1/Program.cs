using PizzaApp.Application.Repository;
using PizzaApp.Application.Services;
using PizzaApp.Application.Services.ExternalServices;
using PizzaApp.Application.Services.Implementation;
using PizzaApp.Domain.Models;
using PizzaApp.Infrastracute;
using PizzaApp.StaticDb.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddMvc().AddNewtonsoftJson();
builder.Services.AddTransient<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<Pizza>, PizzaRepository>();
builder.Services.AddSingleton<IRepository<User>, UserRepository>();
//builder.Services.AddSingleton<IRepository<Order>, OrderEFRepository>();

builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddSingleton<IPizzaService, PizzaService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IEmailSender, EmailSender>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Use(async (context, next) =>
{
    // 
    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
    try {
        logger.LogDebug(message: "The request is {0}", context.Request);
        await next();
    }
    catch (ArgumentException ex)
    {
        logger.LogWarning(ex, "Bad request");
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Internal server error");
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
    }
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    // tuka ako sakame pred sledniot middleware
    await next();
    // tuka mozeme
});
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
