using System.ComponentModel.DataAnnotations;
using AgroFuturo.Api.Models.Enums;

namespace AgroFuturo.Api.Models;

public class Pulverizadora
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Modelo { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? NumeroSerie { get; set; }

    [MaxLength(80)]
    public string? Fabricante { get; set; }

    public StatusPulverizadora Status { get; set; } = StatusPulverizadora.Parada;

    public decimal PressaoMaximaBar { get; set; } = 3.5m;

    public decimal VelocidadeMaximaKmh { get; set; } = 12.0m;

    public bool LimitarVelocidade { get; set; } = true;

    public bool PararEmAlertaPraga { get; set; }

    public int QuantidadeSensores { get; set; }

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public List<Sensor> Sensores { get; set; } = [];

    public List<Pulverizacao> Pulverizacoes { get; set; } = [];
}