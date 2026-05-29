using System.ComponentModel.DataAnnotations;
using AgroFuturo.Api.Models.Enums;

namespace AgroFuturo.Api.Models;

public class Insumo
{
    public int Id { get; set; }

    [Required, MaxLength(120)]
    public string Nome { get; set; } = string.Empty;

    public TipoInsumo Tipo { get; set; }

    public TipoEconomia Economia { get; set; }

    [MaxLength(20)]
    public string UnidadeMedida { get; set; } = "L\\u\\kg";

    public decimal PrecoUnitario { get; set; }

    [MaxLength(80)]
    public string? Fabricante { get; set; }

    [MaxLength(255)]
    public string? Descricao { get; set; }

    public bool Ativo { get; set; } = true;

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public ICollection<ConsumoInsumo> Consumos { get; set; } = new List<ConsumoInsumo>();
}