using MyBank.Application.DTOs;
using MyBank.Domain.Entities;

namespace MyBank.Application.Interfaces;

public interface IMyBankRepository
{
    Task<IEnumerable<Transaccion>> GetAllAsync();

    Task<Transaccion?> GetByIdAsync(int id);

    Task AddAsync(Transaccion transaccion);

    Task UpdateAsync(Transaccion transaccion);

    Task DeleteAsync(Transaccion transaccion);

    Task<ResumenTransaccionesDto> GetResumenAsync();
}