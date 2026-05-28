
using System.ComponentModel.DataAnnotations;

namespace AgroFuturo.Api.Models;

public class Empresa
{
    public int Id { get; set; }

    [Required, MaxLength(150)]
    public string Nome { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? CnpjCpf { get; set; }

    [MaxLength(100)]
    public string? Cidade { get; set; }

    [MaxLength(2)]
    public string? Estado { get; set; }

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public ICollection<Fazenda> Fazendas { get; set; } = new List<Fazenda>();
}
