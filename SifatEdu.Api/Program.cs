using Microsoft.EntityFrameworkCore;
using SifatEdu.Api.Extentions;
using SifatEdu.Api.Middlewares;
using SifatEdu.Data.Contexts;
using System.Text.Json.Serialization;
using System.Text.Json;
using SifatEdu.Service.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

PathHelper.WebRootPath = Path.GetFullPath("wwwroot");

// Database

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Custom Services
builder.Services.AddServices();

builder.Services.ConfigureSwagger();

// JWT
builder.Services.AddJwt(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
