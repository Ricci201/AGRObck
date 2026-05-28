using AgroFuturo.Api.Data;
using AgroFuturo.Api.DTOs;
using AgroFuturo.Api.Models;
using AgroFuturo.Api.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgroFuturo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AppDbContext db) : ControllerBase
{
    [HttpPost("cadastro")]
    public async Task<ActionResult<UsuarioResponseDto>> Cadastro([FromBody] CadastroUsuarioDto dto)
    {
        if (dto.Senha != dto.ConfirmarSenha)
            return BadRequest(new { mensagem = "Senha e confirmação não conferem." });

        if (await db.Usuarios.AnyAsync(u => u.Email == dto.Email))
            return Conflict(new { mensagem = "E-mail já cadastrado." });

        var plano = await db.Planos.FirstOrDefaultAsync(p => p.Tipo == dto.Plano);
        if (plano is null)
            return BadRequest(new { mensagem = "Plano inválido." });

        var empresa = new Empresa { Nome = dto.Empresa };
        db.Empresas.Add(empresa);
        await db.SaveChangesAsync();

        var usuario = new Usuario
        {
            NomeCompleto = dto.NomeCompleto,
            Email = dto.Email,
            Telefone = dto.Telefone,
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
            EmpresaId = empresa.Id,
            PlanoId = plano.Id
        };
        db.Usuarios.Add(usuario);
        await db.SaveChangesAsync();

        return CreatedAtAction(nameof(Cadastro),
            new UsuarioResponseDto(usuario.Id, usuario.NomeCompleto, usuario.Email,
                usuario.Telefone, empresa.Nome, plano.Nome));
    }

    [HttpPost("login")]
    public async Task<ActionResult<UsuarioResponseDto>> Login([FromBody] LoginDto dto)
    {
        var usuario = await db.Usuarios
            .Include(u => u.Empresa)
            .Include(u => u.Plano)
            .FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (usuario is null || !BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash))
            return Unauthorized(new { mensagem = "Credenciais inválidas." });

        usuario.UltimoLogin = DateTime.UtcNow;
        await db.SaveChangesAsync();

        return Ok(new UsuarioResponseDto(usuario.Id, usuario.NomeCompleto, usuario.Email,
            usuario.Telefone, usuario.Empresa?.Nome, usuario.Plano?.Nome ?? string.Empty));
    }
}