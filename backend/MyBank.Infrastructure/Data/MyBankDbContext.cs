using Microsoft.EntityFrameworkCore;
using MyBank.Domain.Entities;

namespace MyBank.Infrastructure.Data;

public class MyBankDbContext : DbContext
{
    public MyBankDbContext(DbContextOptions<MyBankDbContext> options)
        : base(options)
    {
    }

    public DbSet<Transaccion> Transacciones { get; set; }
}