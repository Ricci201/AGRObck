using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CulturaController : CrudControllerBase<Cultura>
{
    public CulturaController(AppDbContext db) : base(db) { }
}
