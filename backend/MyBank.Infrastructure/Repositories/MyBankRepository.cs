using Microsoft.EntityFrameworkCore;
using MyBank.Application.Interfaces;
using MyBank.Domain.Entities;
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
        return await _context.Transacciones.ToListAsync();
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
}