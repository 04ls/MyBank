using MyBank.Domain.Entities;

namespace MyBank.Application.Interfaces;

public interface IMyBankRepository
{
    Task<IEnumerable<Transaccion>> GetAllAsync();

    Task<Transaccion?> GetByIdAsync(int id);

    Task AddAsync(Transaccion transaccion);
}