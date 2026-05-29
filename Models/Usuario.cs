
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroFuturo.Api.Models;

public class Usuario
{
    public int Id { get; set; }

    [Required, MaxLength(150)]
    public string NomeCompleto { get; set; } = string.Empty;

    [Required, MaxLength(150), EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Senha { get; set; } = string.Empty;

    [Required]
    public string SenhaHash { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? Telefone { get; set; }

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? UltimoLogin { get; set; }

    public int? EmpresaId { get; set; }

    public Empresa? Empresa { get; set; }

    public int PlanoId { get; set; }

    public Plano? Plano { get; set; }
}
