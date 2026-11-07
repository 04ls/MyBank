using Microsoft.EntityFrameworkCore;
using MyBank.Application.DTOs;
using MyBank.Application.Interfaces;
using MyBank.Domain.Entities;
using MyBank.Domain.Enums;
using MyBank.Infrastructure.Data;

namespace MyBank.Infrastructure.Repositories;

public class MyBankRepository : IMyBankRepository
{
    private readonly MyBankDbContext _context;

    public MyBankRepository(MyBankDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Transaccion>> GetAllAsync()
    {
        return await _context.Transacciones
            .OrderByDescending(t => t.Fecha)
            .ThenByDescending(t => t.Id)
            .ToListAsync();
    }

    public async Task<Transaccion?> GetByIdAsync(int id)
    {
        return await _context.Transacciones.FindAsync(id);
    }

    public async Task AddAsync(Transaccion transaccion)
    {
        await _context.Transacciones.AddAsync(transaccion);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Transaccion transaccion)
    {
        _context.Transacciones.Update(transaccion);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Transaccion transaccion)
    {
        _context.Transacciones.Remove(transaccion);
        await _context.SaveChangesAsync();
    }

    public async Task<ResumenTransaccionesDto> GetResumenAsync()
    {
        var totalIngresos = await _context.Transacciones
            .Where(t => t.Tipo == TipoTransaccion.Ingreso)
            .SumAsync(t => t.Cantidad);

        var totalGastos = await _context.Transacciones
            .Where(t => t.Tipo == TipoTransaccion.Gasto)
            .SumAsync(t => t.Cantidad);

        return new ResumenTransaccionesDto
        {
            TotalIngresos = totalIngresos,
            TotalGastos = totalGastos,
            Saldo = totalIngresos - totalGastos
        };
    }
}