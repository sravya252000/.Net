/*using ModelsAndInterfaces;
using Methods;
using Database;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IManagementService, ManagementServices>();
builder.Services.AddScoped<IDoctorService, DoctorServices>();
builder.Services.AddScoped<IPatientService,PatientServices>();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(Options =>
{
    Options.UseNpgsql(
        connectionString: "Host=Localhost; Port = 5432; User Id = postgres; Password=Sravya@154;Database= SampleDatabase; Pooling = true;");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
*/
using ModelsAndInterfaces;
using Methods;
using Database;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IManagementService, ManagementServices>();
builder.Services.AddScoped<IDoctorService, DoctorServices>();
builder.Services.AddScoped<IPatientService, PatientServices>();
builder.Services.AddTransient<IEmailService, EmailServices>();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(
        connectionString: "Host=Localhost;Port=5432;UserId=postgres;Password=Sravya@154;Database=SampleDatabase;Pooling=true;");
});

var app = builder.Build();
app.UseCors(options => options
.AllowAnyOrigin().
AllowAnyMethod().
AllowAnyHeader());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<RequestValidationMiddleware>();
app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();

// Custom middleware components
public class RequestValidationMiddleware
{
    private readonly RequestDelegate _next;

    public RequestValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Implement request validation logic
        await _next(context);
    }
}

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
        Console.WriteLine("Login was succesfull");
    }

    public async Task Invoke(HttpContext context)
    {
        // Implement logging logic
        await _next(context);
    }
}

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            // Handle exceptions and provide appropriate responses
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync("Internal Server Error");
        }
    }
}
