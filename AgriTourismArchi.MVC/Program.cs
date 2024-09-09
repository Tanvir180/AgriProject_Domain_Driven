using AgriTourismArchi.Handler;
using AgriTourismArchi.Handler.Interfaces;
using AgriTourismArchi.Repository;
using AgriTourismArchi.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register services before building the app

// Register ICategoryRepository and its implementation
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Register ICategoryHandler and its implementation
builder.Services.AddScoped<ICategoryHandler, CategoryHandler>();

// Register IPaymentHandler and its implementation
builder.Services.AddScoped<IPaymentHandler, PaymentHandler>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

// Register IUserRepository and its implementation
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Register IUserHandler and its implementation
builder.Services.AddScoped<IUserHandler, UserHandler>();

// Add ApplicationDbContext to the .NET Core framework
builder.Services.AddDbContext<AgriTourismArchi.Repository.Data.ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container
builder.Services.AddControllersWithViews();








// Add required services
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

var app = builder.Build(); // Build the app after all services are registered

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Make sure authentication middleware is used
app.UseAuthorization();  // Make sure authorization middleware is used

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
