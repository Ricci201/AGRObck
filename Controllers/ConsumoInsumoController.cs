using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsumoInsumoController : CrudControllerBase<ConsumoInsumo>
{
    public ConsumoInsumoController(AppDbContext db) : base(db) { }
}
