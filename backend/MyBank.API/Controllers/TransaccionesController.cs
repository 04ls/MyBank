using Microsoft.AspNetCore.Mvc;
using MyBank.Application.DTOs;
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
    public async Task<ActionResult<IEnumerable<TransaccionResponseDto>>> GetAll()
    {
        var transacciones = await _repository.GetAllAsync();

        var respuesta = transacciones.Select(t => new TransaccionResponseDto
        {
            Id = t.Id,
            Nombre = t.Nombre,
            Descripcion = t.Descripcion,
            Cantidad = t.Cantidad,
            Tipo = t.Tipo,
            Fecha = t.Fecha
        });

        return Ok(respuesta);
    }

    // GET: api/transacciones/1
    [HttpGet("{id}")]
    public async Task<ActionResult<TransaccionResponseDto>> GetById(int id)
    {
        var transaccion = await _repository.GetByIdAsync(id);

        if (transaccion is null)
            return NotFound();

        var respuesta = new TransaccionResponseDto
        {
            Id = transaccion.Id,
            Nombre = transaccion.Nombre,
            Descripcion = transaccion.Descripcion,
            Cantidad = transaccion.Cantidad,
            Tipo = transaccion.Tipo,
            Fecha = transaccion.Fecha
        };

        return Ok(respuesta);
    }

    // POST: api/transacciones
    [HttpPost]
    public async Task<ActionResult<TransaccionResponseDto>> Create(
        CrearTransaccionDto dto)
    {
        var transaccion = new Transaccion
        {
            Nombre = dto.Nombre.Trim(),
            Descripcion = string.IsNullOrWhiteSpace(dto.Descripcion)
                ? null
                : dto.Descripcion.Trim(),
            Cantidad = dto.Cantidad,
            Tipo = dto.Tipo
        };

        await _repository.AddAsync(transaccion);

        var respuesta = new TransaccionResponseDto
        {
            Id = transaccion.Id,
            Nombre = transaccion.Nombre,
            Descripcion = transaccion.Descripcion,
            Cantidad = transaccion.Cantidad,
            Tipo = transaccion.Tipo,
            Fecha = transaccion.Fecha
        };

        return CreatedAtAction(
            nameof(GetById),
            new { id = transaccion.Id },
            respuesta
        );
    }

    // PUT: api/transacciones/1
    [HttpPut("{id}")]
    public async Task<ActionResult<TransaccionResponseDto>> Update(
        int id,
        ActualizarTransaccionDto dto)
    {
        var transaccion = await _repository.GetByIdAsync(id);

        if (transaccion is null)
            return NotFound();

        transaccion.Nombre = dto.Nombre.Trim();
        transaccion.Descripcion = string.IsNullOrWhiteSpace(dto.Descripcion)
            ? null
            : dto.Descripcion.Trim();
        transaccion.Cantidad = dto.Cantidad;
        transaccion.Tipo = dto.Tipo;

        await _repository.UpdateAsync(transaccion);

        var respuesta = new TransaccionResponseDto
        {
            Id = transaccion.Id,
            Nombre = transaccion.Nombre,
            Descripcion = transaccion.Descripcion,
            Cantidad = transaccion.Cantidad,
            Tipo = transaccion.Tipo,
            Fecha = transaccion.Fecha
        };

        return Ok(respuesta);
    }

    // DELETE: api/transacciones/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var transaccion = await _repository.GetByIdAsync(id);

        if (transaccion is null)
            return NotFound();

        await _repository.DeleteAsync(transaccion);

        return NoContent();
    }

    // GET: api/transacciones/resumen
    [HttpGet("resumen")]
    public async Task<ActionResult<ResumenTransaccionesDto>> GetResumen()
    {
        var resumen = await _repository.GetResumenAsync();

        return Ok(resumen);
    }
}