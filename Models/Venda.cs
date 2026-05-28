using System.ComponentModel.DataAnnotations.Schema;
using AgroFuturo.Api.Models.Enums;

namespace AgroFuturo.Api.Models;

public class Venda
{
    public int Id { get; set; }

    public DateTime DataVenda { get; set; } = DateTime.UtcNow;

    public int QuantidadeSensores { get; set; }

    public decimal ValorTotal { get; set; }

    public decimal? Desconto { get; set; }

    public int ClienteId { get; set; }

    public Cliente? Cliente { get; set; }

    public List<ItemVenda> Itens { get; set; } = [];
}