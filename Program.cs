
using Microsoft.EntityFrameworkCore;
using stationService.src.Data;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Builder DBcontex
string ConnectionString = Environment.GetEnvironmentVariable("StationConnectionString") ?? throw new InvalidOperationException("StationConnectionString no encontrado.");
builder.Services.AddDbContext<TestingDBContext>(options =>
 options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();


