
using System.ComponentModel.DataAnnotations;
using AgroFuturo.Api.Models.Enums;

namespace AgroFuturo.Api.Models;

public class Plano
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Nome { get; set; } = string.Empty;

    public TipoPlano Tipo { get; set; }

    [Range(0, double.MaxValue)]
    public decimal PrecoMensal { get; set; }

    public int LimiteSensores { get; set; }

    [MaxLength(255)]
    public string? Descricao { get; set; }

    public bool Ativo { get; set; } = true;

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}