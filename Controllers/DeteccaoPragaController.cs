using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeteccaoPragaController : CrudControllerBase<DeteccaoPraga>
{
    public DeteccaoPragaController(AppDbContext db) : base(db) { }
}
