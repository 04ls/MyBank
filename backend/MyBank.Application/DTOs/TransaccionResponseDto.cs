using MyBank.Domain.Enums;

namespace MyBank.Application.DTOs;

public class TransaccionResponseDto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    public decimal Cantidad { get; set; }

    public TipoTransaccion Tipo { get; set; }

    public DateTime Fecha { get; set; }
}