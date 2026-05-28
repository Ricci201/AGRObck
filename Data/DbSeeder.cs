using AgroFuturo.Api.Models;
using AgroFuturo.Api.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace AgroFuturo.Api.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        await db.Database.MigrateAsync();

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

        await db.SaveChangesAsync();
    }
}