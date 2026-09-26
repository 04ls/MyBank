using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyBank.Infrastructure.Data;

public class MyBankDbContextFactory
    : IDesignTimeDbContextFactory<MyBankDbContext>
{
    public MyBankDbContext CreateDbContext(string[] args)
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);

        FileInfo? envFile = null;

        while (directory != null)
        {
            var candidate = Path.Combine(directory.FullName, ".env");

            if (File.Exists(candidate))
            {
                envFile = new FileInfo(candidate);
                break;
            }

            directory = directory.Parent;
        }

        if (envFile == null)
        {
            throw new FileNotFoundException(
                "No se encontró el archivo .env."
            );
        }

        var envLine = File.ReadAllLines(envFile.FullName)
            .FirstOrDefault(line =>
                line.StartsWith(
                    "ConnectionStrings__PostgresConnection="
                )
            );

        if (string.IsNullOrWhiteSpace(envLine))
        {
            throw new InvalidOperationException(
                $"No se encontró ConnectionStrings__PostgresConnection en: {envFile.FullName}"
            );
        }

        var connectionString = envLine[
            "ConnectionStrings__PostgresConnection=".Length..
        ].Trim();

        connectionString = connectionString.Trim('"');

        var optionsBuilder =
            new DbContextOptionsBuilder<MyBankDbContext>();

        optionsBuilder.UseNpgsql(connectionString);

        return new MyBankDbContext(optionsBuilder.Options);
    }
}