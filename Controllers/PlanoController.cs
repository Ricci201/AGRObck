using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlanoController : CrudControllerBase<Plano>
{
    public PlanoController(AppDbContext db) : base(db) { }
}
