
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Transaccion>(entity =>
        {
            entity.HasKey(t => t.Id);

            entity.Property(t => t.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(t => t.Descripcion)
                .HasMaxLength(250)
                .IsRequired(false);

            entity.Property(t => t.Cantidad)
                .HasPrecision(12, 2);

            entity.Property(t => t.Tipo)
                .IsRequired();

            entity.Property(t => t.Fecha)
                .IsRequired();
        });
    }
}
