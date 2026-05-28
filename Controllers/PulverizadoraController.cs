using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PulverizadoraController : CrudControllerBase<Pulverizadora>
{
    public PulverizadoraController(AppDbContext db) : base(db) { }
}
