using System.ComponentModel.DataAnnotations.Schema;

namespace AgroFuturo.Api.Models;

public class ConsumoInsumo
{
    public int Id { get; set; }

    public DateTime DataConsumo { get; set; } = DateTime.UtcNow;

    public decimal QuantidadeConsumida { get; set; }

    public decimal CustoTotal { get; set; }

    public decimal? EconomiaPercentual { get; set; }

    public int InsumoId { get; set; }
    [ForeignKey(nameof(InsumoId))]
    public Insumo? Insumo { get; set; }

    public int TalhaoId { get; set; }
    [ForeignKey(nameof(TalhaoId))]
    public Talhao? Talhao { get; set; }
}