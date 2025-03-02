using BusinessLayer.Interface;
using NLog;
using NLog.Web;
using HelloApp.Middleware;
using BusinessLayer.Service;
using RepositoryLayer.Service;
using RepositoryLayer.Interface;
using RepositoryLayer.Context;
using Microsoft.EntityFrameworkCore;


var logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();
try
{
    logger.Info("Application is starting...");
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

   


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<RegisterHelloBL>();
builder.Services.AddScoped<RegisterHelloRL> ();
builder.Services.AddScoped<IRegistrationHelloBL, RegisterHelloBL>();
builder.Services.AddScoped<IRegistrationHelloRL, RegisterHelloRL>();
var connectionString=
builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HelloAppContext>(options =>
options.UseSqlServer(connectionString));

//Add Swagger to container
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Application encountered an error.");
    throw;
}
finally
{
    LogManager.Shutdown();
}
