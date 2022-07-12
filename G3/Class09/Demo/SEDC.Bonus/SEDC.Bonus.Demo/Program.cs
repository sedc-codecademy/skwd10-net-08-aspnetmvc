var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

// users/born/1993/02
app.MapControllerRoute(
    name: "UsersBornOnDate",
    pattern: "users/born/{year}/{month}",
    defaults: new { controller = "User", action = "BornOnDate" },
    constraints: new { year = @"\d{4}", month = @"\d{2}" }
    );

// users/employment/1993/developer
app.MapControllerRoute(
    name: "UsersByEmploymentYearAndPosition",
    pattern: "users/employment/{year}/{position}",
    defaults: new { controller = "User", action = "ByEmploymentYearAndPosition" }
    );

// users/employment/1993
app.MapControllerRoute(
    name: "UsersByEmploymentYear",
    pattern: "users/employment/{year}",
    defaults: new { controller = "User", action = "ByEmploymentYear" }
    );

// users
app.MapControllerRoute(
    name: "AllUsers",
    pattern: "users",
    defaults: new { controller = "User", action = "GetAllEmployees" }
    );


app.Run();
