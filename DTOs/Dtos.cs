using System.ComponentModel.DataAnnotations;
using AgroFuturo.Api.Models.Enums;

namespace AgroFuturo.Api.DTOs;

public record CadastroUsuarioDto(
    [Required] string NomeCompleto,
    [Required] string Empresa,
    [Required, EmailAddress] string Email,
    string? Telefone,
    [Required, MinLength(6)] string Senha,
    [Required] string ConfirmarSenha,
    TipoPlano Plano
);

public record LoginDto([Required, EmailAddress] string Email, [Required] string Senha);

public record UsuarioResponseDto(int Id, string NomeCompleto, string Email, string? Telefone, string? Empresa, string Plano);

public record PlanoDto(
    [Required] string Nome,
    TipoPlano Tipo,
    decimal PrecoMensal,
    int LimiteSensores,
    string? Descricao
);

public record EmpresaDto(
    [Required] string Nome,
    string? CnpjCpf,
    string? Cidade,
    string? Estado
);

public record FazendaDto(
    [Required] string Nome,
    string? Localizacao,
    string? Cidade,
    string? Estado,
    decimal AreaTotalHa,
    double? Latitude,
    double? Longitude,
    int EmpresaId
);

public record CulturaDto(
    [Required] string Nome,
    string? CodigoCor,
    string? Descricao
);

public record TalhaoDto(
    [Required] string Identificador,
    decimal AreaHa,
    StatusTalhao Status,
    int PercentualConcluido,
    int FazendaId,
    int CulturaId
);

public record PulverizadoraDto(
    [Required] string Modelo,
    string? NumeroSerie,
    string? Fabricante,
    StatusPulverizadora Status,
    decimal PressaoMaximaBar,
    decimal VelocidadeMaximaKmh,
    bool LimitarVelocidade,
    bool PararEmAlertaPraga,
    int QuantidadeSensores
);

public record ModeloSensorDto(
    [Required] string Nome,
    string? Codigo,
    decimal PrecoUnitario,
    decimal MargemPercentual,
    string? Descricao
);

public record SensorDto(
    [Required] string Codigo,
    [Required] string Descricao,
    BracoPulverizadora Braco,
    int PosicaoBraco,
    StatusSensor Status,
    int NivelBateria,
    int PulverizadoraId,
    int ModeloSensorId
);

public record LeituraSensorDto(
    decimal TemperaturaC,
    decimal UmidadePercentual,
    decimal PressaoBar,
    decimal FluxoLitrosMin,
    int SensorId
);

public record PulverizacaoDto(
    DateTime DataInicio,
    DateTime? DataFim,
    StatusTalhao Status,
    int PercentualConcluido,
    decimal HectaresPulverizados,
    decimal? VelocidadeMediaKmh,
    decimal? TemperaturaAmbienteC,
    decimal? UmidadeSoloPercentual,
    int TalhaoId,
    int PulverizadoraId
);

public record PragaDto(
    [Required] string Nome,
    string? NomeCientifico,
    string? Descricao,
    string? RecomendacaoTratamento
);

public record DeteccaoPragaDto(
    string? Setor,
    NivelSeveridadePraga Severidade,
    decimal ConfiancaIa,
    string? Observacoes,
    int PragaId,
    int TalhaoId
);

public record InsumoDto(
    [Required] string Nome,
    TipoInsumo Tipo,
    string UnidadeMedida,
    decimal PrecoUnitario,
    string? Fabricante,
    string? Descricao
);

public record ConsumoInsumoDto(
    DateTime DataConsumo,
    decimal QuantidadeConsumida,
    decimal CustoTotal,
    decimal? EconomiaPercentual,
    int InsumoId,
    int TalhaoId
);

public record ClienteDto(
    [Required] string Nome,
    string? CnpjCpf,
    string? Email,
    string? Telefone,
    string? Cidade,
    string? Estado
);

public record ItemVendaDto(int Quantidade, decimal PrecoUnitario, int ModeloSensorId);

public record VendaDto(
    DateTime DataVenda,
    int QuantidadeSensores,
    decimal ValorTotal,
    decimal? Desconto,
    StatusVenda Status,
    string? Observacoes,
    int ClienteId,
    List<ItemVendaDto> Itens
);

public record ConfiguracaoSistemaDto(
    bool ModoEscuro,
    IntervaloLeitura IntervaloLeitura,
    bool AlertasSensorAtivos,
    bool AutoCalibracao,
    string UrlApi,
    bool AutenticacaoJwt,
    int UsuarioId
);