using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgroFuturo.Api.Controllers;

/// <summary>
/// Controller base genérico para CRUDs simples.
/// </summary>
public abstract class CrudControllerBase<TEntity> : ControllerBase where TEntity : class
{
    protected readonly AppDbContext db;
    protected CrudControllerBase(AppDbContext db) => this.db = db;

    protected DbSet<TEntity> Set => db.Set<TEntity>();

    [HttpGet]
    public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        => Ok(await Set.AsNoTracking().ToListAsync());

    [HttpGet("{id:int}")]
    public virtual async Task<ActionResult<TEntity>> GetById(int id)
    {
        var entity = await Set.FindAsync(id);
        return entity is null ? NotFound() : Ok(entity);
    }

    [HttpDelete("{id:int}")]
    public virtual async Task<IActionResult> Delete(int id)
    {
        var entity = await Set.FindAsync(id);
        if (entity is null) return NotFound();
        Set.Remove(entity);
        await db.SaveChangesAsync();
        return NoContent();
    }
}