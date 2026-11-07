using System.ComponentModel.DataAnnotations;
using MyBank.Domain.Enums;

namespace MyBank.Application.DTOs;

public class CrearTransaccionDto
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(250, ErrorMessage = "La descripción no puede superar los 250 caracteres.")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "La cantidad es obligatoria.")]
    [Range(typeof(decimal), "0.01", "9999999999.99",
        ErrorMessage = "La cantidad debe ser mayor que cero.")]
    public decimal Cantidad { get; set; }

    [Required(ErrorMessage = "El tipo de transacción es obligatorio.")]
    [EnumDataType(typeof(TipoTransaccion),
        ErrorMessage = "El tipo de transacción no es válido.")]
    public TipoTransaccion Tipo { get; set; }
}