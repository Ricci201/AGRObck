using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendaController : CrudControllerBase<Venda>
{
    public VendaController(AppDbContext db) : base(db) { }
}
