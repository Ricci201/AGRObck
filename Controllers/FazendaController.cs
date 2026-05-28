using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FazendaController : CrudControllerBase<Fazenda>
{
    public FazendaController(AppDbContext db) : base(db) { }
}
