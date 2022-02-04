using TestApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
//var connection = Configuration.GetConnectionString("TestApplicationDatabase");

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TestApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TestApplicationDatabase")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapControllers();

app.MapFallbackToFile("index.html"); ;

app.Run();
