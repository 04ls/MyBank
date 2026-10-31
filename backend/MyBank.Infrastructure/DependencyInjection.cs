using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBank.Application.Interfaces;
using MyBank.Infrastructure.Data;
using MyBank.Infrastructure.Repositories;

namespace MyBank.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        // Configuración de PostgreSQL
        services.AddDbContext<MyBankDbContext>(options =>
            options.UseNpgsql(connectionString));

        // Registro del repositorio
        services.AddScoped<IMyBankRepository, MyBankRepository>();

        return services;
    }
}