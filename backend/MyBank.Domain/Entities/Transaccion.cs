using MyBank.Domain.Enums;

namespace MyBank.Domain.Entities;

public class Transaccion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty;

    public decimal Cantidad { get; set; }

    public TipoTransaccion Tipo { get; set; }

    public DateTime Fecha { get; set; } = DateTime.UtcNow;
}