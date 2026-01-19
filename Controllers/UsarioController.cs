using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SsiApi.Data;
using SsiApi.DTOs;
using SsiApi.Models;

namespace SsiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Usuarios.ToListAsync());
        }

        [HttpGet("{chapa}")]

        public async Task<IActionResult> GetById(string chapa)
        {
            var usuario = await _context.Usuarios.FindAsync(chapa);
            if (usuario == null) return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUsuarioDtos dto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Chapa == dto.Chapa))
                return BadRequest("Chapa já cadastrada!");

            var usuario = new Usuario
            {
                Chapa = dto.Chapa,
                Nome = dto.Nome,
                Ramal = dto.Ramal,
                Senha = dto.Senha, // depois vamos hashear
                TipoUsuario = dto.TipoUsuario,
                AreaTecnico = dto.AreaTecnico,
                Mostrar = 'S'
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { chapa = usuario.Chapa }, usuario);
        }

        [HttpPut("{chapa}")]
        public async Task<IActionResult> Update(string chapa, UpdateUsuarioDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(chapa);

            if (usuario == null)
                return NotFound();

            usuario.Nome = dto.Nome;
            usuario.Ramal = dto.Ramal;
            usuario.TipoUsuario = dto.TipoUsuario;
            usuario.AreaTecnico = dto.AreaTecnico;
            usuario.Mostrar = dto.Mostrar;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{chapa}")]
        public async Task<IActionResult> Delete(string chapa)
        {
            var usuario = await _context.Usuarios.FindAsync(chapa);
            if (usuario == null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}