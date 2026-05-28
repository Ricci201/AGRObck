using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgroFuturo.Api.Models.Enums;

namespace AgroFuturo.Api.Models;

public class DeteccaoPraga
{
    public int Id { get; set; }

    public DateTime DetectadoEm { get; set; } = DateTime.UtcNow;

    [MaxLength(50)]
    public string? Setor { get; set; } 

    public NivelSeveridadePraga Severidade { get; set; } = NivelSeveridadePraga.Medio;

    [Range(0, 100)]
    public decimal ConfiancaIa { get; set; }

    [MaxLength(500)]
    public string? Observacoes { get; set; }

    public bool Resolvida { get; set; }

    public int PragaId { get; set; }
    [ForeignKey(nameof(PragaId))]
    public Praga? Praga { get; set; }

    public int TalhaoId { get; set; }
    [ForeignKey(nameof(TalhaoId))]
    public Talhao? Talhao { get; set; }
}