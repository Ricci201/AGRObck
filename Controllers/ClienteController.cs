using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : CrudControllerBase<Cliente>
{
    public ClienteController(AppDbContext db) : base(db) { }
}
