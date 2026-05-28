using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PragaController : CrudControllerBase<Praga>
{
    public PragaController(AppDbContext db) : base(db) { }
}
