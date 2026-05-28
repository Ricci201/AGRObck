namespace AgroFuturo.Api.Models.Enums;

public enum TipoPlano
{
    Basico = 1,
    Pro = 2,
    Enterprise = 3
}

public enum StatusTalhao
{
    Aguardando = 0,
    Pulverizando = 1,
    Concluido = 2,
    Alerta = 3
}

public enum StatusSensor
{
    Inativo = 0,
    Ativo = 1,
    Alerta = 2,
    Falha = 3
}

public enum BracoPulverizadora
{
    Esquerdo = 1,
    Direito = 2
}

public enum StatusPulverizadora
{
    Parada = 0,
    Operando = 1,
    Manutencao = 2,
    Alerta = 3
}

public enum NivelSeveridadePraga
{
    Baixo = 1,
    Medio = 2,
    Alto = 3,
    Critico = 4
}

public enum TipoInsumo
{
    Herbicida = 1,
    Fungicida = 2,
    Inseticida = 3,
    Fertilizante = 4,
    Adjuvante = 5
}

public enum TipoEconomia
{
    Nenhuma = 0,
    Baixa = 1,
    Media = 2,
    Alta = 3
}

public enum StatusVenda
{
    Pendente = 0,
    Confirmada = 1,
    Faturada = 2,
    Cancelada = 3
}

public enum IntervaloLeitura
{
    Ms100 = 100,
    Ms250 = 250,
    Ms500 = 500,
    Ms1000 = 1000,
    Ms5000 = 5000
}