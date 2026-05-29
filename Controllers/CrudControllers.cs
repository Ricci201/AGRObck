using AgroFuturo.Api.Data;
using AgroFuturo.Api.DTOs;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgroFuturo.Api.Controllers;

[ApiController, Route("api/[controller]")]
public class PlanosController(AppDbContext dbContext) : CrudControllerBase<Plano>(dbContext)
{
    [HttpPost]
    public async Task<ActionResult<Plano>> Create(PlanoDto dto)
    {
        var entity = new Plano
        {
            Nome = dto.Nome,
            Tipo = dto.Tipo,
            PrecoMensal = dto.PrecoMensal,
            LimiteSensores = dto.LimiteSensores,
            Descricao = dto.Descricao
        };
        db.Planos.Add(entity);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, PlanoDto dto)
    {
        var entity = await db.Planos.FindAsync(id);
        if (entity is null) return NotFound();
        entity.Nome = dto.Nome; entity.Tipo = dto.Tipo; entity.PrecoMensal = dto.PrecoMensal;
        entity.LimiteSensores = dto.LimiteSensores; entity.Descricao = dto.Descricao;
        await db.SaveChangesAsync();
        return NoContent();
    }
}

[ApiController, Route("api/[controller]")]
public class EmpresasController(AppDbContext dbContext) : CrudControllerBase<Empresa>(dbContext)
{
    [HttpPost]
    public async Task<ActionResult<Empresa>> Create(EmpresaDto dto)
    {
        var entity = new Empresa { Nome = dto.Nome, CnpjCpf = dto.CnpjCpf, Cidade = dto.Cidade, Estado = dto.Estado };
        db.Empresas.Add(entity); await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, EmpresaDto dto)
    {
        var e = await db.Empresas.FindAsync(id);
        if (e is null) return NotFound();
        e.Nome = dto.Nome; e.CnpjCpf = dto.CnpjCpf; e.Cidade = dto.Cidade; e.Estado = dto.Estado;
        await db.SaveChangesAsync();
        return NoContent();
    }
}

[ApiController, Route("api/[controller]")]
public class FazendasController(AppDbContext dbContext) : CrudControllerBase<Fazenda>(dbContext)
{
    [HttpPost]
    public async Task<ActionResult<Fazenda>> Create(FazendaDto dto)
    {
        var entity = new Fazenda
        {
            Nome = dto.Nome,
            Localizacao = dto.Localizacao,
            Cidade = dto.Cidade,
            Estado = dto.Estado,
            AreaTotalHa = dto.AreaTotalHa,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            EmpresaId = dto.EmpresaId
        };
        db.Fazendas.Add(entity); await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, FazendaDto dto)
    {
        var f = await db.Fazendas.FindAsync(id);
        if (f is null) return NotFound();
        f.Nome = dto.Nome; f.Localizacao = dto.Localizacao; f.Cidade = dto.Cidade; f.Estado = dto.Estado;
        f.AreaTotalHa = dto.AreaTotalHa; f.Latitude = dto.Latitude; f.Longitude = dto.Longitude;
        f.EmpresaId = dto.EmpresaId;
        await db.SaveChangesAsync();
        return NoContent();
    }
}

[ApiController, Route("api/[controller]")]
public class CulturasController(AppDbContext dbContext) : CrudControllerBase<Cultura>(dbContext)
{
    [HttpPost]
    public async Task<ActionResult<Cultura>> Create(CulturaDto dto)
    {
        var entity = new Cultura { Nome = dto.Nome, CodigoCor = dto.CodigoCor, Descricao = dto.Descricao };
        db.Culturas.Add(entity); await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, CulturaDto dto)
    {
        var c = await db.Culturas.FindAsync(id);
        if (c is null) return NotFound();
        c.Nome = dto.Nome; c.CodigoCor = dto.CodigoCor; c.Descricao = dto.Descricao;
        await db.SaveChangesAsync();
        return NoContent();
    }
}

[ApiController, Route("api/[controller]")]
public class TalhoesController(AppDbContext dbContext) : CrudControllerBase<Talhao>(dbContext)
{
    [HttpPost]
    public async Task<ActionResult<Talhao>> Create(TalhaoDto dto)
    {
        var entity = new Talhao
        {
            Identificador = dto.Identificador,
            AreaHa = dto.AreaHa,
            Status = dto.Status,
            PercentualConcluido = dto.PercentualConcluido,
            FazendaId = dto.FazendaId,
            CulturaId = dto.CulturaId
        };
        db.Talhoes.Add(entity); await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, TalhaoDto dto)
    {
        var t = await db.Talhoes.FindAsync(id);
        if (t is null) return NotFound();
        t.Identificador = dto.Identificador; t.AreaHa = dto.AreaHa; t.Status = dto.Status;
        t.PercentualConcluido = dto.PercentualConcluido; t.FazendaId = dto.FazendaId; t.CulturaId = dto.CulturaId;
        await db.SaveChangesAsync();
        return NoContent();
    }
}

[ApiController, Route("api/[controller]")]
public class PulverizadorasController(AppDbContext dbContext) : CrudControllerBase<Pulverizadora>(dbContext)
{
    [HttpPost]
    public async Task<ActionResult<Pulverizadora>> Create(PulverizadoraDto dto)
    {
        var entity = new Pulverizadora
        {
            Modelo = dto.Modelo,
            NumeroSerie = dto.NumeroSerie,
            Fabricante = dto.Fabricante,
            Status = dto.Status,
            PressaoMaximaBar = dto.PressaoMaximaBar,
            VelocidadeMaximaKmh = dto.VelocidadeMaximaKmh,
            LimitarVelocidade = dto.LimitarVelocidade,
            PararEmAlertaPraga = dto.PararEmAlertaPraga,
            QuantidadeSensores = dto.QuantidadeSensores
        };
        db.Pulverizadoras.Add(entity); await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, PulverizadoraDto dto)
    {
        var p = await db.Pulverizadoras.FindAsync(id);
        if (p is null) return NotFound();
        p.Modelo = dto.Modelo; p.NumeroSerie = dto.NumeroSerie; p.Fabricante = dto.Fabricante;
        p.Status = dto.Status; p.PressaoMaximaBar = dto.PressaoMaximaBar;
        p.VelocidadeMaximaKmh = dto.VelocidadeMaximaKmh; p.LimitarVelocidade = dto.LimitarVelocidade;
        p.PararEmAlertaPraga = dto.PararEmAlertaPraga; p.QuantidadeSensores = dto.QuantidadeSensores;
        await db.SaveChangesAsync();
        return NoContent();
    }
}

[ApiController, Route("api/[controller]")]
public class ModelosSensorController(AppDbContext dbContext) : CrudControllerBase<ModeloSensor>(dbContext)
{
    [HttpPost]
    public async Task<ActionResult<ModeloSensor>> Create(ModeloSensorDto dto)
    {
        var entity = new ModeloSensor
        {
            Nome = dto.Nome,
            Codigo = dto.Codigo,
            PrecoUnitario = dto.PrecoUnitario,
            MargemPercentual = dto.MargemPercentual,
            Descricao = dto.Descricao
        };
        db.ModelosSensor.Add(entity); await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, ModeloSensorDto dto)
    {
        var m = await db.ModelosSensor.FindAsync(id);
        if (m is null) return NotFound();
        m.Nome = dto.Nome; m.Codigo = dto.Codigo; m.PrecoUnitario = dto.PrecoUnitario;
        m.MargemPercentual = dto.MargemPercentual; m.Descricao = dto.Descricao;
        await db.SaveChangesAsync();
        return NoContent();
    }
}

[ApiController, Route("api/[controller]")]
public class SensoresController(AppDbContext dbContext) : CrudControllerBase<Sensor>(dbContext)
{
    [HttpPost]
    public async Task<ActionResult<Sensor>> Create(SensorDto dto)
    {
        var entity = new Sensor
        {
            Codigo = dto.Codigo,
            Descricao = dto.Descricao,
            Braco = dto.Braco,
            PosicaoBraco = dto.PosicaoBraco,
            Status = dto.Status,
            NivelBateria = dto.NivelBateria,
            PulverizadoraId = dto.PulverizadoraId,
            ModeloSensorId = dto.ModeloSensorId
        };
        db.Sensores.Add(entity); await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, SensorDto dto)
    {
        var s = await db.Sensores.FindAsync(id);
        if (s is null) return NotFound();
        s.Codigo = dto.Codigo; s.Descricao = dto.Descricao; s.Braco = dto.Braco;
        s.PosicaoBraco = dto.PosicaoBraco; s.Status = dto.Status; s.NivelBateria = dto.NivelBateria;
        s.PulverizadoraId = dto.PulverizadoraId; s.ModeloSensorId = dto.ModeloSensorId;
        await db.SaveChangesAsync();
        return NoContent();
    }
}

[ApiController, Route("api/leituras-sensor")]
public class LeiturasSensorController(AppDbContext dbContext) : ControllerBase
{
    private readonly AppDbContext db = dbContext;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeituraSensor>>> GetAll([FromQuery] int? sensorId)
    {
        var q = db.LeiturasSensor.AsNoTracking().AsQueryable();
        if (sensorId.HasValue) q = q.Where(l => l.SensorId == sensorId.Value);
        return Ok(await q.OrderByDescending(l => l.RegistradoEm).Take(500).ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult<LeituraSensor>> Create(LeituraSensorDto dto)
    {
        var entity = new LeituraSensor
        {
            TemperaturaC = dto.TemperaturaC,
            UmidadePercentual = dto.UmidadePercentual,
            PressaoBar = dto.PressaoBar,
            FluxoLitrosMin = dto.FluxoLitrosMin,
            SensorId = dto.SensorId
        };
        db.LeiturasSensor.Add(entity); await db.SaveChangesAsync();
        return Created("api/leituras-sensor/{id}", entity);
    }
}

[ApiController, Route("api/[controller]")]
public class PulverizacoesController(AppDbContext dbContext) : CrudControllerBase<Pulverizacao>(dbContext)
{
    [HttpPost]
    public async Task<ActionResult<Pulverizacao>> Create(PulverizacaoDto dto)
    {
        var entity = new Pulverizacao
        {
            DataInicio = dto.DataInicio,
            DataFim = dto.DataFim,
            Status = dto.Status,
            PercentualConcluido = dto.PercentualConcluido,
            HectaresPulverizados = dto.HectaresPulverizados,
            VelocidadeMediaKmh = dto.VelocidadeMediaKmh,
            TemperaturaAmbienteC = dto.TemperaturaAmbienteC,
            UmidadeSoloPercentual = dto.UmidadeSoloPercentual,
            TalhaoId = dto.TalhaoId,
            PulverizadoraId = dto.PulverizadoraId
        };
        db.Pulverizacoes.Add(entity); await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, PulverizacaoDto dto)
    {
        var p = await db.Pulverizacoes.FindAsync(id);
        if (p is null) return NotFound();
        p.DataInicio = dto.DataInicio; p.DataFim = dto.DataFim; p.Status = dto.Status;
        p.PercentualConcluido = dto.PercentualConcluido; p.HectaresPulverizados = dto.HectaresPulverizados;
        p.VelocidadeMediaKmh = dto.VelocidadeMediaKmh; p.TemperaturaAmbienteC = dto.TemperaturaAmbienteC;
        p.UmidadeSoloPercentual = dto.UmidadeSoloPercentual; p.TalhaoId = dto.TalhaoId;
        p.PulverizadoraId = dto.PulverizadoraId;
        await db.SaveChangesAsync();
        return NoContent();
    }
}

[ApiController, Route("api/[controller]")]
public class PragasController(AppDbContext dbContext) : CrudControllerBase<Praga>(dbContext)
{
    [HttpPost]
    public async Task<ActionResult<Praga>> Create(PragaDto dto)
    {
        var entity = new Praga
        {
            Nome = dto.Nome,
            NomeCientifico = dto.NomeCientifico,
            Descricao = dto.Descricao,
            RecomendacaoTratamento = dto.RecomendacaoTratamento
        };
        db.Pragas.Add(entity); await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, PragaDto dto)
    {
        var p = await db.Pragas.FindAsync(id);
        if (p is null) return NotFound();
        p.Nome = dto.Nome; p.NomeCientifico = dto.NomeCientifico;
        p.Descricao = dto.Descricao; p.RecomendacaoTratamento = dto.RecomendacaoTratamento;
        await db.SaveChangesAsync();
        return NoContent();
    }
}

[ApiController, Route("api/deteccoes-praga")]
public class DeteccoesPragaController(AppDbContext dbContext) : CrudControllerBase<DeteccaoPraga>(dbContext)
{
    [HttpPost]
    public async Task<ActionResult<DeteccaoPraga>> Create(DeteccaoPragaDto dto)
    {
        var entity = new DeteccaoPraga
        {
            Setor = dto.Setor,
            Severidade = dto.Severidade,
            ConfiancaIa = dto.ConfiancaIa,
            Observacoes = dto.Observacoes,
            PragaId = dto.PragaId,
            TalhaoId = dto.TalhaoId
        };
        db.DeteccoesPraga.Add(entity); await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }
}

[ApiController, Route("api/[controller]")]
public class InsumosController(AppDbContext dbContext) : CrudControllerBase<Insumo>(dbContext)
{
    [HttpPost]
    public async Task<ActionResult<Insumo>> Create(InsumoDto dto)
    {
        var entity = new Insumo
        {
            Nome = dto.Nome,
            Tipo = dto.Tipo,
            UnidadeMedida = dto.UnidadeMedida,
            PrecoUnitario = dto.PrecoUnitario,
            Fabricante = dto.Fabricante,
            Descricao = dto.Descricao
        };
        db.Insumos.Add(entity); await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, InsumoDto dto)
    {
        var i = await db.Insumos.FindAsync(id);
        if (i is null) return NotFound();
        i.Nome = dto.Nome; i.Tipo = dto.Tipo; i.UnidadeMedida = dto.UnidadeMedida;
        i.PrecoUnitario = dto.PrecoUnitario; i.Fabricante = dto.Fabricante; i.Descricao = dto.Descricao;
        await db.SaveChangesAsync();
        return NoContent();
    }
}

[ApiController, Route("api/consumos-insumo")]
public class ConsumosInsumoController(AppDbContext dbContext) : CrudControllerBase<ConsumoInsumo>(dbContext)
{
    [HttpPost]
    public async Task<ActionResult<ConsumoInsumo>> Create(ConsumoInsumoDto dto)
    {
        var entity = new ConsumoInsumo
        {
            DataConsumo = dto.DataConsumo,
            QuantidadeConsumida = dto.QuantidadeConsumida,
            CustoTotal = dto.CustoTotal,
            EconomiaPercentual = dto.EconomiaPercentual,
            InsumoId = dto.InsumoId,
            TalhaoId = dto.TalhaoId
        };
        db.ConsumosInsumo.Add(entity); await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }
}

[ApiController, Route("api/[controller]")]
public class ClientesController(AppDbContext dbContext) : CrudControllerBase<Cliente>(dbContext)
{
    [HttpPost]
    public async Task<ActionResult<Cliente>> Create(ClienteDto dto)
    {
        var entity = new Cliente
        {
            Nome = dto.Nome,
            CnpjCpf = dto.CnpjCpf,
            Email = dto.Email,
            Telefone = dto.Telefone,
            Cidade = dto.Cidade,
            Estado = dto.Estado
        };
        db.Clientes.Add(entity); await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, ClienteDto dto)
    {
        var c = await db.Clientes.FindAsync(id);
        if (c is null) return NotFound();
        c.Nome = dto.Nome; c.CnpjCpf = dto.CnpjCpf; c.Email = dto.Email;
        c.Telefone = dto.Telefone; c.Cidade = dto.Cidade; c.Estado = dto.Estado;
        await db.SaveChangesAsync();
        return NoContent();
    }
}

[ApiController, Route("api/[controller]")]
public class VendasController(AppDbContext dbContext) : CrudControllerBase<Venda>(dbContext)
{
    public override async Task<ActionResult<IEnumerable<Venda>>> GetAll()
        => Ok(await db.Vendas.Include(v => v.Cliente).Include(v => v.Itens).AsNoTracking().ToListAsync());

    [HttpPost]
    public async Task<ActionResult<Venda>> Create(VendaDto dto)
    {
        var entity = new Venda
        {
            DataVenda = dto.DataVenda,
            QuantidadeSensores = dto.QuantidadeSensores,
            ValorTotal = dto.ValorTotal,
            Desconto = dto.Desconto,
            Status = dto.Status,
            Observacoes = dto.Observacoes,
            ClienteId = dto.ClienteId,
            Itens = dto.Itens.Select(i => new ItemVenda
            {
                Quantidade = i.Quantidade,
                PrecoUnitario = i.PrecoUnitario,
                Subtotal = i.Quantidade * i.PrecoUnitario,
                ModeloSensorId = i.ModeloSensorId
            }).ToList()
        };
        db.Vendas.Add(entity); await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }
}

[ApiController, Route("api/configuracoes")]
public class ConfiguracoesController(AppDbContext dbContext) : ControllerBase
{
    private readonly AppDbContext db = dbContext;

    [HttpGet("{usuarioId:int}")]
    public async Task<ActionResult<ConfiguracaoSistema>> Get(int usuarioId)
    {
        var cfg = await db.ConfiguracoesSistema.FirstOrDefaultAsync<ConfiguracaoSistema>(c => c.UsuarioId == usuarioId);
        return cfg is null ? NotFound() : Ok(cfg);
    }

    [HttpPut]
    public async Task<ActionResult<ConfiguracaoSistema>> Upsert(ConfiguracaoSistemaDto dto)
    {
        var cfg = await db.ConfiguracoesSistema.FirstOrDefaultAsync<ConfiguracaoSistema>(c => c.UsuarioId == dto.UsuarioId);
        if (cfg is null)
        {
            cfg = new ConfiguracaoSistema { UsuarioId = dto.UsuarioId };
            db.ConfiguracoesSistema.Add(cfg);
        }
        cfg.ModoEscuro = dto.ModoEscuro;
        cfg.IntervaloLeitura = dto.IntervaloLeitura;
        cfg.AlertasSensorAtivos = dto.AlertasSensorAtivos;
        cfg.AutoCalibracao = dto.AutoCalibracao;
        cfg.UrlApi = dto.UrlApi;
        cfg.AutenticacaoJwt = dto.AutenticacaoJwt;
        cfg.AtualizadoEm = DateTime.UtcNow;
        await db.SaveChangesAsync();
        return Ok(cfg);
    }
}