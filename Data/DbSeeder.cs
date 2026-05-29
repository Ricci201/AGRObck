using AgroFuturo.Api.Models;
using AgroFuturo.Api.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace AgroFuturo.Api.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (db.Database.ProviderName?.Contains("Sqlite", StringComparison.OrdinalIgnoreCase) == true)
        {
            await db.Database.EnsureCreatedAsync();
        }
        else
        {
            await db.Database.MigrateAsync();
        }

        if (!await db.Planos.AnyAsync())
        {
            db.Planos.AddRange(
                new Plano { Nome = "Básico", Tipo = TipoPlano.Basico, PrecoMensal = 290m, LimiteSensores = 12, Descricao = "Até 12 sensores" },
                new Plano { Nome = "Pro", Tipo = TipoPlano.Pro, PrecoMensal = 490m, LimiteSensores = 24, Descricao = "Até 24 sensores" },
                new Plano { Nome = "Enterprise", Tipo = TipoPlano.Enterprise, PrecoMensal = 0m, LimiteSensores = 9999, Descricao = "Sob consulta" }
            );
        }

        if (!await db.Culturas.AnyAsync())
        {
            db.Culturas.AddRange(
                new Cultura { Nome = "Soja", CodigoCor = "#22c55e" },
                new Cultura { Nome = "Milho", CodigoCor = "#3b82f6" },
                new Cultura { Nome = "Algodão", CodigoCor = "#f59e0b" },
                new Cultura { Nome = "Sorgo", CodigoCor = "#60a5fa" }
            );
        }

        if (!await db.ModelosSensor.AnyAsync())
        {
            db.ModelosSensor.AddRange(
                new ModeloSensor { Nome = "AgroSensor PRO X1", Codigo = "PRO-X1", PrecoUnitario = 4700m, MargemPercentual = 42m },
                new ModeloSensor { Nome = "AgroSensor LITE S3", Codigo = "LITE-S3", PrecoUnitario = 3300m, MargemPercentual = 35m },
                new ModeloSensor { Nome = "AgroSensor ULTRA V2", Codigo = "ULTRA-V2", PrecoUnitario = 3100m, MargemPercentual = 51m }
            );
        }

        if (!await db.Empresas.AnyAsync())
        {
            db.Empresas.AddRange(
                new Empresa { Nome = "Fazenda Agro Vale", CnpjCpf = "12345678000190", Cidade = "Ribeirão Preto", Estado = "SP" },
                new Empresa { Nome = "Cooperativa Cerrado", CnpjCpf = "23456789000191", Cidade = "Rio Verde", Estado = "GO" }
            );
        }

        if (!await db.Pragas.AnyAsync())
        {
            db.Pragas.AddRange(
                new Praga { Nome = "Lagarta-da-soja", NomeCientifico = "Anticarsia gemmatalis", Descricao = "Praga comum em soja", RecomendacaoTratamento = "Monitorar e aplicar controle biológico" },
                new Praga { Nome = "Pulgão", NomeCientifico = "Aphis gossypii", Descricao = "Afeta culturas de algodão e hortaliças", RecomendacaoTratamento = "Aplicação seletiva de inseticida" }
            );
        }

        if (!await db.Insumos.AnyAsync())
        {
            db.Insumos.AddRange(
                new Insumo { Nome = "Herbicida Delta", Tipo = TipoInsumo.Herbicida, Economia = TipoEconomia.Media, UnidadeMedida = "L", PrecoUnitario = 82.5m, Fabricante = "AgroChem" },
                new Insumo { Nome = "Fungicida Protect", Tipo = TipoInsumo.Fungicida, Economia = TipoEconomia.Alta, UnidadeMedida = "L", PrecoUnitario = 97.9m, Fabricante = "Campo Forte" }
            );
        }

        if (!await db.Clientes.AnyAsync())
        {
            db.Clientes.AddRange(
                new Cliente { Nome = "Cliente Validação A", CnpjCpf = "34567890000192", Email = "cliente.a@agrofuturo.com", Telefone = "11999990001", Cidade = "Piracicaba", Estado = "SP" },
                new Cliente { Nome = "Cliente Validação B", CnpjCpf = "45678901000193", Email = "cliente.b@agrofuturo.com", Telefone = "11999990002", Cidade = "Jataí", Estado = "GO" }
            );
        }

        await db.SaveChangesAsync();

        var planoBasico = await db.Planos.FirstAsync(p => p.Tipo == TipoPlano.Basico);
        var planoPro = await db.Planos.FirstAsync(p => p.Tipo == TipoPlano.Pro);
        var empresaVale = await db.Empresas.FirstAsync(e => e.CnpjCpf == "12345678000190");
        var empresaCerrado = await db.Empresas.FirstAsync(e => e.CnpjCpf == "23456789000191");

        if (!await db.Usuarios.AnyAsync())
        {
            db.Usuarios.AddRange(
                new Usuario
                {
                    NomeCompleto = "Admin Agro Vale",
                    Email = "admin.vale@agrofuturo.com",
                    Telefone = "11988887777",
                    Senha = "123456",
                    SenhaHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    EmpresaId = empresaVale.Id,
                    PlanoId = planoBasico.Id
                },
                new Usuario
                {
                    NomeCompleto = "Operador Cerrado",
                    Email = "operador.cerrado@agrofuturo.com",
                    Telefone = "64988887777",
                    Senha = "123456",
                    SenhaHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    EmpresaId = empresaCerrado.Id,
                    PlanoId = planoPro.Id
                }
            );
            await db.SaveChangesAsync();
        }

        if (!await db.Fazendas.AnyAsync())
        {
            db.Fazendas.AddRange(
                new Fazenda
                {
                    Nome = "Unidade Norte",
                    Cidade = "Ribeirão Preto",
                    Estado = "SP",
                    Localizacao = "Zona Rural - Km 12",
                    AreaTotalHa = 850m,
                    Latitude = -21.1767,
                    Longitude = -47.8208,
                    EmpresaId = empresaVale.Id
                },
                new Fazenda
                {
                    Nome = "Unidade Oeste",
                    Cidade = "Rio Verde",
                    Estado = "GO",
                    Localizacao = "Rodovia GO-174",
                    AreaTotalHa = 1210m,
                    Latitude = -17.7929,
                    Longitude = -50.9193,
                    EmpresaId = empresaCerrado.Id
                }
            );
            await db.SaveChangesAsync();
        }

        var culturaSoja = await db.Culturas.FirstAsync(c => c.Nome == "Soja");
        var culturaMilho = await db.Culturas.FirstAsync(c => c.Nome == "Milho");
        var fazendaNorte = await db.Fazendas.FirstAsync(f => f.Nome == "Unidade Norte");
        var fazendaOeste = await db.Fazendas.FirstAsync(f => f.Nome == "Unidade Oeste");

        if (!await db.Talhoes.AnyAsync())
        {
            db.Talhoes.AddRange(
                new Talhao { Identificador = "TAL-001", AreaHa = 120m, Status = StatusTalhao.Aguardando, PercentualConcluido = 0, FazendaId = fazendaNorte.Id, CulturaId = culturaSoja.Id },
                new Talhao { Identificador = "TAL-002", AreaHa = 95m, Status = StatusTalhao.Aguardando, PercentualConcluido = 0, FazendaId = fazendaOeste.Id, CulturaId = culturaMilho.Id }
            );
            await db.SaveChangesAsync();
        }

        if (!await db.Pulverizadoras.AnyAsync())
        {
            db.Pulverizadoras.AddRange(
                new Pulverizadora { Modelo = "PulvMax 3000", NumeroSerie = "PM3000-001", Fabricante = "AgroMachines", Status = StatusPulverizadora.Operando, PressaoMaximaBar = 4.2m, VelocidadeMaximaKmh = 14.5m, LimitarVelocidade = true, QuantidadeSensores = 8 },
                new Pulverizadora { Modelo = "FieldSpray 2X", NumeroSerie = "FS2X-008", Fabricante = "Field Tech", Status = StatusPulverizadora.Parada, PressaoMaximaBar = 3.8m, VelocidadeMaximaKmh = 13.2m, LimitarVelocidade = true, QuantidadeSensores = 6 }
            );
            await db.SaveChangesAsync();
        }

        var modeloPro = await db.ModelosSensor.FirstAsync(m => m.Codigo == "PRO-X1");
        var modeloLite = await db.ModelosSensor.FirstAsync(m => m.Codigo == "LITE-S3");
        var pulverizadoraA = await db.Pulverizadoras.FirstAsync(p => p.NumeroSerie == "PM3000-001");
        var pulverizadoraB = await db.Pulverizadoras.FirstAsync(p => p.NumeroSerie == "FS2X-008");

        if (!await db.Sensores.AnyAsync())
        {
            db.Sensores.AddRange(
                new Sensor { Codigo = "SEN-001", Descricao = "Sensor braço esquerdo", Braco = BracoPulverizadora.Esquerdo, PosicaoBraco = 1, Status = StatusSensor.Ativo, NivelBateria = 94, PulverizadoraId = pulverizadoraA.Id, ModeloSensorId = modeloPro.Id },
                new Sensor { Codigo = "SEN-002", Descricao = "Sensor braço direito", Braco = BracoPulverizadora.Direito, PosicaoBraco = 1, Status = StatusSensor.Ativo, NivelBateria = 90, PulverizadoraId = pulverizadoraB.Id, ModeloSensorId = modeloLite.Id }
            );
            await db.SaveChangesAsync();
        }

        var sensorEsquerdo = await db.Sensores.FirstAsync(s => s.Codigo == "SEN-001");
        var sensorDireito = await db.Sensores.FirstAsync(s => s.Codigo == "SEN-002");

        if (!await db.LeiturasSensor.AnyAsync())
        {
            db.LeiturasSensor.AddRange(
                new LeituraSensor { SensorId = sensorEsquerdo.Id, TemperaturaC = 27.8m, UmidadePercentual = 64.2m, PressaoBar = 3.2m, FluxoLitrosMin = 22.5m },
                new LeituraSensor { SensorId = sensorDireito.Id, TemperaturaC = 28.3m, UmidadePercentual = 61.8m, PressaoBar = 3.1m, FluxoLitrosMin = 21.9m }
            );
            await db.SaveChangesAsync();
        }

        var talhao1 = await db.Talhoes.FirstAsync(t => t.Identificador == "TAL-001");
        var talhao2 = await db.Talhoes.FirstAsync(t => t.Identificador == "TAL-002");
        var praga1 = await db.Pragas.FirstAsync(p => p.Nome == "Lagarta-da-soja");
        var praga2 = await db.Pragas.FirstAsync(p => p.Nome == "Pulgão");
        var insumo1 = await db.Insumos.FirstAsync(i => i.Nome == "Herbicida Delta");
        var insumo2 = await db.Insumos.FirstAsync(i => i.Nome == "Fungicida Protect");

        if (!await db.Pulverizacoes.AnyAsync())
        {
            db.Pulverizacoes.AddRange(
                new Pulverizacao
                {
                    TalhaoId = talhao1.Id,
                    PulverizadoraId = pulverizadoraA.Id,
                    DataInicio = DateTime.UtcNow.AddHours(-2),
                    DataFim = DateTime.UtcNow.AddHours(-1),
                    Status = StatusTalhao.Concluido,
                    PercentualConcluido = 100,
                    HectaresPulverizados = 118.6m,
                    VelocidadeMediaKmh = 10.5m,
                    TemperaturaAmbienteC = 28.1m,
                    UmidadeSoloPercentual = 52.3m
                },
                new Pulverizacao
                {
                    TalhaoId = talhao2.Id,
                    PulverizadoraId = pulverizadoraB.Id,
                    DataInicio = DateTime.UtcNow.AddHours(-4),
                    DataFim = DateTime.UtcNow.AddHours(-3),
                    Status = StatusTalhao.Concluido,
                    PercentualConcluido = 100,
                    HectaresPulverizados = 93.8m,
                    VelocidadeMediaKmh = 9.9m,
                    TemperaturaAmbienteC = 27.2m,
                    UmidadeSoloPercentual = 49.6m
                }
            );
            await db.SaveChangesAsync();
        }

        if (!await db.DeteccoesPraga.AnyAsync())
        {
            db.DeteccoesPraga.AddRange(
                new DeteccaoPraga { TalhaoId = talhao1.Id, PragaId = praga1.Id, Setor = "A1", Severidade = NivelSeveridadePraga.Medio, ConfiancaIa = 92.4m, Observacoes = "Pontos isolados", Resolvida = false },
                new DeteccaoPraga { TalhaoId = talhao2.Id, PragaId = praga2.Id, Setor = "B3", Severidade = NivelSeveridadePraga.Alto, ConfiancaIa = 95.1m, Observacoes = "Ação recomendada em 24h", Resolvida = false }
            );
            await db.SaveChangesAsync();
        }

        if (!await db.ConsumosInsumo.AnyAsync())
        {
            db.ConsumosInsumo.AddRange(
                new ConsumoInsumo { TalhaoId = talhao1.Id, InsumoId = insumo1.Id, DataConsumo = DateTime.UtcNow.AddDays(-1), QuantidadeConsumida = 84.3m, CustoTotal = 6954.75m, EconomiaPercentual = 12.5m },
                new ConsumoInsumo { TalhaoId = talhao2.Id, InsumoId = insumo2.Id, DataConsumo = DateTime.UtcNow.AddDays(-1), QuantidadeConsumida = 62.7m, CustoTotal = 6138.33m, EconomiaPercentual = 9.8m }
            );
            await db.SaveChangesAsync();
        }

        if (!await db.Vendas.AnyAsync())
        {
            var clienteA = await db.Clientes.FirstAsync(c => c.Email == "cliente.a@agrofuturo.com");

            db.Vendas.Add(new Venda
            {
                ClienteId = clienteA.Id,
                DataVenda = DateTime.UtcNow.AddDays(-3),
                QuantidadeSensores = 2,
                ValorTotal = 8000m,
                Desconto = 250m,
                Status = StatusVenda.Faturada,
                Observacoes = "Venda de validação",
                Itens =
                [
                    new ItemVenda { ModeloSensorId = modeloPro.Id, Quantidade = 1, PrecoUnitario = 4700m, Subtotal = 4700m },
                    new ItemVenda { ModeloSensorId = modeloLite.Id, Quantidade = 1, PrecoUnitario = 3300m, Subtotal = 3300m }
                ]
            });
            await db.SaveChangesAsync();
        }

        if (!await db.ConfiguracoesSistema.AnyAsync())
        {
            var usuarioAdmin = await db.Usuarios.FirstAsync(u => u.Email == "admin.vale@agrofuturo.com");
            db.ConfiguracoesSistema.Add(new ConfiguracaoSistema
            {
                UsuarioId = usuarioAdmin.Id,
                ModoEscuro = false,
                IntervaloLeitura = IntervaloLeitura.Ms1000,
                AlertasSensorAtivos = true,
                AutoCalibracao = true,
                UrlApi = "https://api.agrofuturo.local/v1",
                AutenticacaoJwt = false
            });
            await db.SaveChangesAsync();
        }
    }
}