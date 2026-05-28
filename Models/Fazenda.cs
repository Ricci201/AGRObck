using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroFuturo.Api.Models;

public class Fazenda
{
    public int Id { get; set; }

    [Required, MaxLength(150)]
    public string Nome { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? Cidade { get; set; }

    [MaxLength(2)]
    public string? Estado { get; set; }

    public decimal AreaTotal { get; set; }

    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public int EmpresaId { get; set; }

    public Empresa? Empresa { get; set; }

    public ICollection<Talhao> Talhoes { get; set; } = new List<Talhao>();
}