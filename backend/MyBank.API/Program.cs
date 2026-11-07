using DotNetEnv;
using MyBank.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Cargar variables de entorno desde el archivo .env local
var envPath = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, "../../../..", ".env")
);

Env.Load(envPath);

var connectionString =
    Environment.GetEnvironmentVariable("ConnectionStrings__PostgresConnection")
    ?? throw new InvalidOperationException("Falta la cadena de conexión.");

builder.Services.AddInfrastructure(connectionString);

builder.Services.AddControllers();

//Configuración CORS para permitir solicitudes desde React
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddOpenApi();

var app = builder.Build();
app.UseCors("Frontend");

app.MapGet("/", () => "MyBank API funcionando correctamente");
app.MapControllers();

app.Run();