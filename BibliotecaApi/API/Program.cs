using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using API.Extensions;
using AspNetCoreRateLimit;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddAplicacionServices();
builder.Services.AddJwt(builder.Configuration);
builder.Services.ConfigureRatelimiting();
builder.Services.ConfigureApiVersioning();
builder.Services.ConfigureJson();


builder.Services.AddDbContext<APIContext>(option => {
    string conexion = builder.Configuration.GetConnectionString("DefaultCon");
    option.UseMySql(conexion, ServerVersion.AutoDetect(conexion));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseIpRateLimiting();
app.UseAuthorization();

app.MapControllers();

app.Run();
