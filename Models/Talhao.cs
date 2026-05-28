using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgroFuturo.Api.Models.Enums;

namespace AgroFuturo.Api.Models;

public class Talhao
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Identificador { get; set; } = string.Empty; 

    public decimal AreaHa { get; set; }

    public StatusTalhao Status { get; set; } = StatusTalhao.Aguardando;

    [Range(0, 100)]
    public int PercentualConcluido { get; set; }

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public int FazendaId { get; set; }
    [ForeignKey(nameof(FazendaId))]
    public Fazenda? Fazenda { get; set; }

    public int CulturaId { get; set; }
    [ForeignKey(nameof(CulturaId))]
    public Cultura? Cultura { get; set; }

    public ICollection<Pulverizacao> Pulverizacoes { get; set; } = new List<Pulverizacao>();
    public ICollection<DeteccaoPraga> DeteccoesPraga { get; set; } = new List<DeteccaoPraga>();
    public ICollection<ConsumoInsumo> Consumos { get; set; } = new List<ConsumoInsumo>();
}