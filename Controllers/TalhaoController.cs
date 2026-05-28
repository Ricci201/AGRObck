using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TalhaoController : CrudControllerBase<Talhao>
{
    public TalhaoController(AppDbContext db) : base(db) { }
}
