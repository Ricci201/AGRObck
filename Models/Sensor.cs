using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgroFuturo.Api.Models.Enums;

namespace AgroFuturo.Api.Models;

public class Sensor
{
    public int Id { get; set; }

    [Required, MaxLength(20)]
    public string Codigo { get; set; } = string.Empty; 

    [Required, MaxLength(80)]
    public string Descricao { get; set; } = string.Empty; 

    public BracoPulverizadora Braco { get; set; }

    public int PosicaoBraco { get; set; }

    public StatusSensor Status { get; set; } = StatusSensor.Ativo;

    [Range(0, 100)]
    public int NivelBateria { get; set; } = 100;

    public DateTime? UltimaLeitura { get; set; }

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public int PulverizadoraId { get; set; }
    [ForeignKey(nameof(PulverizadoraId))]
    public Pulverizadora? Pulverizadora { get; set; }

    public int ModeloSensorId { get; set; }
    [ForeignKey(nameof(ModeloSensorId))]
    public ModeloSensor? ModeloSensor { get; set; }

    public ICollection<LeituraSensor> Leituras { get; set; } = new List<LeituraSensor>();
}