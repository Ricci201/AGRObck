using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorController : CrudControllerBase<Sensor>
{
    public SensorController(AppDbContext db) : base(db) { }
}
