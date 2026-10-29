using DatabaseService;
using DatabaseService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options=>options.UseSqlServer(connection));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => Cart.GetCart(sp));
builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStatusCodePages();
app.MapControllers();

app.UseStaticFiles();
app.UseSession();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    ).WithStaticAssets();

app.Run();

