using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgroFuturo.Api.Models.Enums;

namespace AgroFuturo.Api.Models;

public class ConfiguracaoSistema
{
    public int Id { get; set; }

    public bool ModoEscuro { get; set; } = true;

    public IntervaloLeitura IntervaloLeitura { get; set; } = IntervaloLeitura.Ms500;

    public bool AlertasSensorAtivos { get; set; } = true;

    [MaxLength(255)]
    public string UrlApi { get; set; } = "https://api.agrofuturo.local/v1";

    public bool AutenticacaoJwt { get; set; } = true;

    public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;

    public int UsuarioId { get; set; }
    [ForeignKey(nameof(UsuarioId))]
    public Usuario? Usuario { get; set; }
}