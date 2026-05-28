using System.ComponentModel.DataAnnotations.Schema;
using AgroFuturo.Api.Models.Enums;

namespace AgroFuturo.Api.Models;

public class Pulverizacao
{
    public int Id { get; set; }

    public DateTime DataInicio { get; set; } = DateTime.UtcNow;

    public DateTime? DataFim { get; set; }

    public StatusTalhao Status { get; set; } = StatusTalhao.Aguardando;

    public int PercentualConcluido { get; set; }

    public decimal HectaresPulverizados { get; set; }

    public decimal? VelocidadeMediaKmh { get; set; }

    public decimal? TemperaturaAmbienteC { get; set; }

    public decimal? UmidadeSoloPercentual { get; set; }

    public int TalhaoId { get; set; }

    public Talhao? Talhao { get; set; }

    public int PulverizadoraId { get; set; }

    public Pulverizadora? Pulverizadora { get; set; }
}