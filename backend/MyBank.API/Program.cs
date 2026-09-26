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

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapControllers();

app.Run();