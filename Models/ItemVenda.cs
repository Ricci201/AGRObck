using System.ComponentModel.DataAnnotations.Schema;

namespace AgroFuturo.Api.Models;

public class ItemVenda
{
    public int Id { get; set; }

    public int Quantidade { get; set; }

    public decimal PrecoUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public int VendaId { get; set; }

    public Venda? Venda { get; set; }
    public int ModeloSensorId { get; set; }

    public ModeloSensor? ModeloSensor { get; set; }
}