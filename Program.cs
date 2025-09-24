
using Microsoft.EntityFrameworkCore;
using stationService.src.Data;
using DotNetEnv;
using stationService.src.Interface;
using stationService.src.Repository;

/// <summary>
/// Punto de entrada principal de la aplicacion
/// </summary>

// Cargar variables de entorno desde archivo .env
Env.Load();

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Configuracion de servicios del contenedor de dependencias
/// </summary>
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

/// <summary>
/// Configuracion del contexto de base de datos MySQL
/// Obtiene la cadena de conexion desde variables de entorno
/// Usa ServerVersion.AutoDetect para detectar automaticamente la version de MySQL.
/// </summary>
string ConnectionString = Environment.GetEnvironmentVariable("StationConnectionString") ?? throw new InvalidOperationException("StationConnectionString no encontrado.");
builder.Services.AddDbContext<DBContext>(options => options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)));

/// <summary>
/// Registro de repositorios en el contenedor de inyeccion de dependencias
/// </summary>
builder.Services.AddScoped<IStationRepository, StationRepository>();

/// <summary>
/// Construccion de la aplicación web
/// </summary>
var app = builder.Build();

/// <summary>
/// Configuracion peticiones HTTP
/// Habilitar Swagger solo en entorno de desarrollo
/// </summary>
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapControllers(); 
app.Run();

