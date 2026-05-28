using System.ComponentModel.DataAnnotations.Schema;

namespace AgroFuturo.Api.Models;

public class LeituraSensor
{
    public long Id { get; set; }

    public decimal TemperaturaC { get; set; }

    public decimal UmidadePercentual { get; set; }

    public decimal PressaoBar { get; set; }

    public decimal FluxoLitros { get; set; }

    public DateTime RegistradoEm { get; set; } = DateTime.UtcNow;

    public int SensorId { get; set; }

    public Sensor? Sensor { get; set; }
}