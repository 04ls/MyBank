using Microsoft.EntityFrameworkCore;
using MyBank.Application.Interfaces;
using MyBank.Domain.Entities;
using MyBank.Infrastructure.Data;

namespace MyBank.Infrastructure.Repositories;

//Implementamos la interfaz (la finca obedece a la receta)
public class MyBankRepository: iMyBankRepository {
    private readonly MyBankDbContext _context;

    //El constructor recibe el contexto de EF Core
    public MyBankRepository(MyBankDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<MyBankGlobal>> GetAllAsync() {
        return await _context.MyBanksGlobales.ToListAsync(); //Consulta real a BD (Magia SQL)
    }

    public async Task<MyBankGlobal> AddAsync(MyBankGlobal mybank) {
        await _context.MyBanksGlobales.AddAsync(mybank);

        //SaveChangesAsync envuelve la operación en una transacción SQL (Commit)
        await _context.SaveChangesAsync();

        return mybank;
    }
}