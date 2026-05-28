using System.ComponentModel.DataAnnotations.Schema;

namespace AgroFuturo.Api.Models;

public class ItemVenda
{
    public int Id { get; set; }

    public int Quantidade { get; set; }

    public decimal PrecoUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public int VendaId { get; set; }
    [ForeignKey(nameof(VendaId))]
    public Venda? Venda { get; set; }

    public int ModeloSensorId { get; set; }
    [ForeignKey(nameof(ModeloSensorId))]
    public ModeloSensor? ModeloSensor { get; set; }
}