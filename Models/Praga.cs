using System.ComponentModel.DataAnnotations;

namespace AgroFuturo.Api.Models;

public class Praga
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? NomeCientifico { get; set; }

    [MaxLength(500)]
    public string? Descricao { get; set; }

    [MaxLength(500)]
    public string? RecomendacaoTratamento { get; set; }

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public ICollection<DeteccaoPraga> Deteccoes { get; set; } = new List<DeteccaoPraga>();
}
