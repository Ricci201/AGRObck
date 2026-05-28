using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpresaController : CrudControllerBase<Empresa>
{
    public EmpresaController(AppDbContext db) : base(db) { }
}
