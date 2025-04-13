using CarManagerAPI.Controllers;
using CarManagerAPI.Data;
using CarManagerAPI.Repositories;
using CarManagerAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICarRepository,CarRepository>();
builder.Services.AddDbContext<CarDbContext>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
