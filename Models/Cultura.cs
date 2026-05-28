using System.ComponentModel.DataAnnotations;

namespace AgroFuturo.Api.Models;

public class Cultura
{
    public int Id { get; set; }

    [Required, MaxLength(80)]
    public string Nome { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? CodigoCor { get; set; }

    [MaxLength(255)]
    public string? Descricao { get; set; }

    public bool Ativo { get; set; } = true;

    public ICollection<Talhao> Talhoes { get; set; } = new List<Talhao>();
}