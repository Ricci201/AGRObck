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

        // Precisão decimal consistente para SQL Server
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

        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }

        // Relacionamentos explícitos para evitar múltiplos caminhos de cascade no SQL Server
        modelBuilder.Entity<Fazenda>()
            .HasOne(f => f.Empresa)
            .WithMany(e => e.Fazendas)
            .HasForeignKey(f => f.EmpresaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Talhao>()
            .HasOne(t => t.Fazenda)
            .WithMany(f => f.Talhoes)
            .HasForeignKey(t => t.FazendaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Talhao>()
            .HasOne(t => t.Cultura)
            .WithMany(c => c.Talhoes)
            .HasForeignKey(t => t.CulturaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Sensor>()
            .HasOne(s => s.Pulverizadora)
            .WithMany(p => p.Sensores)
            .HasForeignKey(s => s.PulverizadoraId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Sensor>()
            .HasOne(s => s.ModeloSensor)
            .WithMany(m => m.Sensores)
            .HasForeignKey(s => s.ModeloSensorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<LeituraSensor>()
            .HasOne(l => l.Sensor)
            .WithMany(s => s.Leituras)
            .HasForeignKey(l => l.SensorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Pulverizacao>()
            .HasOne(p => p.Talhao)
            .WithMany(t => t.Pulverizacoes)
            .HasForeignKey(p => p.TalhaoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Pulverizacao>()
            .HasOne(p => p.Pulverizadora)
            .WithMany(pz => pz.Pulverizacoes)
            .HasForeignKey(p => p.PulverizadoraId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DeteccaoPraga>()
            .HasOne(d => d.Praga)
            .WithMany(p => p.Deteccoes)
            .HasForeignKey(d => d.PragaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DeteccaoPraga>()
            .HasOne(d => d.Talhao)
            .WithMany(t => t.DeteccoesPraga)
            .HasForeignKey(d => d.TalhaoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ConsumoInsumo>()
            .HasOne(c => c.Insumo)
            .WithMany(i => i.Consumos)
            .HasForeignKey(c => c.InsumoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ConsumoInsumo>()
            .HasOne(c => c.Talhao)
            .WithMany(t => t.Consumos)
            .HasForeignKey(c => c.TalhaoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Venda>()
            .HasOne(v => v.Cliente)
            .WithMany(c => c.Vendas)
            .HasForeignKey(v => v.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ItemVenda>()
            .HasOne(i => i.Venda)
            .WithMany(v => v.Itens)
            .HasForeignKey(i => i.VendaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ItemVenda>()
            .HasOne(i => i.ModeloSensor)
            .WithMany(m => m.ItensVenda)
            .HasForeignKey(i => i.ModeloSensorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Empresa)
            .WithMany(e => e.Usuarios)
            .HasForeignKey(u => u.EmpresaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Plano)
            .WithMany(p => p.Usuarios)
            .HasForeignKey(u => u.PlanoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ConfiguracaoSistema>()
            .HasOne(c => c.Usuario)
            .WithMany()
            .HasForeignKey(c => c.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ConfiguracaoSistema>()
            .HasIndex(c => c.UsuarioId)
            .IsUnique();
    }
}