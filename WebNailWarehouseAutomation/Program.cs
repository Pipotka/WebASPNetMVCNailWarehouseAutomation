using Microsoft.EntityFrameworkCore;
using WebNailWarehouseAutomation.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration
    .GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<NailContext>
    (options => options.UseSqlServer(connection));

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("Log\\log.txt",
    rollingInterval: RollingInterval.Day,
    rollOnFileSizeLimit: true,
    outputTemplate: "{Timestamp:dd-MM-yyyy HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception} {Properties:j}")
    .WriteTo.Seq("http://localhost:5341")
    .CreateLogger();

Log.Information("Start program");

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

app.Run();

Log.Information("End of program");
Log.CloseAndFlush();