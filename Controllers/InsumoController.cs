using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InsumoController : CrudControllerBase<Insumo>
{
    public InsumoController(AppDbContext db) : base(db) { }
}
