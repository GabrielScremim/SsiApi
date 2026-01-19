using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SsiApi.Data;
using SsiApi.DTOs;
using SsiApi.Models;

namespace SsiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SsiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SsiController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 GET: api/ssi
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ssis = await _context.Ssis
                .Include(s => s.Usuario)
                .Include(s => s.Servico)
                .ToListAsync();

            return Ok(ssis);
        }

        // 🔹 GET: api/ssi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ssi = await _context.Ssis
                .Include(s => s.Usuario)
                .Include(s => s.Servico)
                .FirstOrDefaultAsync(s => s.SsiId == id);

            if (ssi == null)
                return NotFound();

            return Ok(ssi);
        }

        // 🔹 POST: api/ssi
        [HttpPost]
        public async Task<IActionResult> Create(CreateSsiDto dto)
        {
            //valida usuário
            var usuario = await _context.Usuarios.FindAsync(dto.ChapaSolicitante);
            if (usuario == null)
                return BadRequest("Usuário não encontrado");

            // valida serviço
            var servico = await _context.Servicos.FindAsync(dto.ServicoId);
            if (servico == null)
                return BadRequest("Serviço não encontrado");

            var ssi = new Ssi
            {
                ChapaSolicitante = usuario.Chapa,
                NomeSolicitante = usuario.Nome,
                ServicoId = servico.ServicoId,
                DataRegistro = DateTime.Now,
                Andamento = 0
            };

            _context.Ssis.Add(ssi);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = ssi.SsiId }, ssi);
        }

        // 🔹 PUT: api/ssi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSsiDto dto)
        {
            var ssi = await _context.Ssis.FindAsync(id);
            if (ssi == null)
                return NotFound();

            ssi.Andamento = dto.Andamento;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 🔹 DELETE: api/ssi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ssi = await _context.Ssis.FindAsync(id);
            if (ssi == null)
                return NotFound();

            _context.Ssis.Remove(ssi);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
