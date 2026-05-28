using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConfiguracaoSistemaController : CrudControllerBase<ConfiguracaoSistema>
{
    public ConfiguracaoSistemaController(AppDbContext db) : base(db) { }
}
