namespace MyBank.Application.DTOs;

public class ResumenTransaccionesDto
{
    public decimal TotalIngresos { get; set; }

    public decimal TotalGastos { get; set; }

    public decimal Saldo { get; set; }
}