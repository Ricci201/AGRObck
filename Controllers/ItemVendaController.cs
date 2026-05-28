using AgroFuturo.Api.Data;
using AgroFuturo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemVendaController : CrudControllerBase<ItemVenda>
{
    public ItemVendaController(AppDbContext db) : base(db) { }
}
