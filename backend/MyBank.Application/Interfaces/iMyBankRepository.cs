using MyBank.Domain.Entities;

namespace MyBank.Application.Interfaces;

public interface iMyBankRepository {
    Task<IEnumerable<MyBankGlobal>> GetAllAsync();
    Task<MyBankGlobal> AddAsync(MyBankGlobal mybank); //Agregamos el contrato para el POST
}