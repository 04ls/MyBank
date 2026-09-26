using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBank.Application.Interfaces;
using MyBank.Infrastructure.Data;
using MyBank.Infrastructure.Repositories;

namespace MyBank.Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString) {
         //1. Configuramos el acceso a PostgreSQL
         services.AddDbContext<MyBankDbContext>(options =>
            options.UseNpgsql(connectionString));

        //2. LA INYECCION CLAVE (el contrato firmado por el Gerente):
        //"Cada vez que un Chef (controlador) pida la Receta (iMyBankRepository),
        //entrégale los datos de la Finca PostgreSQL (MyBankRepository)"
        services.AddScoped<iMyBankRepository, MyBankRepository>();


        return services;    
    }
}