using AgroFuturo.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroFuturo.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Plano> Planos => Set<Plano>();
    public DbSet<Empresa> Empresas => Set<Empresa>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Cultura> Culturas => Set<Cultura>();
    public DbSet<Fazenda> Fazendas => Set<Fazenda>();
    public DbSet<Talhao> Talhoes => Set<Talhao>();
    public DbSet<Pulverizadora> Pulverizadoras => Set<Pulverizadora>();
    public DbSet<ModeloSensor> ModelosSensor => Set<ModeloSensor>();
    public DbSet<Sensor> Sensores => Set<Sensor>();
    public DbSet<LeituraSensor> LeiturasSensor => Set<LeituraSensor>();
    public DbSet<Pulverizacao> Pulverizacoes => Set<Pulverizacao>();
    public DbSet<Praga> Pragas => Set<Praga>();
    public DbSet<DeteccaoPraga> DeteccoesPraga => Set<DeteccaoPraga>();
    public DbSet<Insumo> Insumos => Set<Insumo>();
    public DbSet<ConsumoInsumo> ConsumosInsumo => Set<ConsumoInsumo>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Venda> Vendas => Set<Venda>();
    public DbSet<ItemVenda> ItensVenda => Set<ItemVenda>();
    public DbSet<ConfiguracaoSistema> ConfiguracoesSistema => Set<ConfiguracaoSistema>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Índices únicos
        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Sensor>()
            .HasIndex(s => s.Codigo)
            .IsUnique();

        modelBuilder.Entity<Plano>()
            .HasIndex(p => p.Tipo)
            .IsUnique();

        // Precisão decimal para PostgreSQL
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?))
                {
                    property.SetPrecision(18);
                    property.SetScale(4);
                }
            }
        }

        // Cascade restrito para evitar deletes em cascata indesejados
        modelBuilder.Entity<Talhao>()
            .HasOne(t => t.Fazenda)
            .WithMany(f => f.Talhoes)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Sensor>()
            .HasOne(s => s.Pulverizadora)
            .WithMany(p => p.Sensores)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ItemVenda>()
            .HasOne(i => i.Venda)
            .WithMany(v => v.Itens)
            .OnDelete(DeleteBehavior.Cascade);
    }
}