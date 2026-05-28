using System.ComponentModel.DataAnnotations;

namespace AgroFuturo.Api.Models;

public class Cliente
{
    public int Id { get; set; }

    [Required, MaxLength(150)]
    public string Nome { get; set; } = string.Empty; 

    [MaxLength(20)]
    public string? CnpjCpf { get; set; }

    [MaxLength(150), EmailAddress]
    public string? Email { get; set; }

    [MaxLength(20)]
    public string? Telefone { get; set; }

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public ICollection<Venda> Vendas { get; set; } = new List<Venda>();
}