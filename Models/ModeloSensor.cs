using System.ComponentModel.DataAnnotations;

namespace AgroFuturo.Api.Models;

public class ModeloSensor
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Nome { get; set; } = string.Empty; 

    [MaxLength(50)]
    public string? Codigo { get; set; }

    public decimal PrecoUnitario { get; set; }

    [Range(0, 100)]
    public decimal MargemPercentual { get; set; }

    [MaxLength(255)]
    public string? Descricao { get; set; }

    public bool Ativo { get; set; } = true;

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public ICollection<Sensor> Sensores { get; set; } = new List<Sensor>();
    public ICollection<ItemVenda> ItensVenda { get; set; } = new List<ItemVenda>();
}