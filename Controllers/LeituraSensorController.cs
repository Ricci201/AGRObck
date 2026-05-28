using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeituraSensorController : CrudControllerBase<LeituraSensor>
{
    public LeituraSensorController(AppDbContext db) : base(db) { }
}
