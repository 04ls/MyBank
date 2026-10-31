
using Microsoft.AspNetCore.Mvc;
using MyBank.Application.Interfaces;
using MyBank.Domain.Entities;

namespace MyBank.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransaccionesController : ControllerBase
{
    private readonly IMyBankRepository _repository;

    public TransaccionesController(IMyBankRepository repository)
    {
        _repository = repository;
    }

    // GET: api/transacciones
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transaccion>>> GetAll()
    {
        var transacciones = await _repository.GetAllAsync();

        return Ok(transacciones);
    }

    // GET: api/transacciones/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Transaccion>> GetById(int id)
    {
        var transaccion = await _repository.GetByIdAsync(id);

        if (transaccion is null)
            return NotFound();

        return Ok(transaccion);
    }

    // POST: api/transacciones
    [HttpPost]
    public async Task<ActionResult> Create(Transaccion transaccion)
    {
        if (transaccion.Cantidad <= 0)
            return BadRequest("La cantidad debe ser mayor que cero.");

        if (!Enum.IsDefined(transaccion.Tipo))
            return BadRequest("El tipo de transacción no es válido.");

        await _repository.AddAsync(transaccion);

        return CreatedAtAction(
            nameof(GetById),
            new { id = transaccion.Id },
            transaccion
        );
    }
}
