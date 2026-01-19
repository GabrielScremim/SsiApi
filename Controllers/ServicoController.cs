using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SsiApi.Data;
using SsiApi.DTOs;
using SsiApi.Models;

namespace SsiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ServicoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServicoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Servicos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var servico = await _context.Servicos.FindAsync(id);
            if (servico == null)
                return NotFound();

            return Ok(servico);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServicoDto dto)
        {
            var servico = new Servico
            {
                NomeServico = dto.NomeServico,
                AreaServico = dto.AreaServico,
                Mostrar = "S"
            };

            _context.Servicos.Add(servico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = servico.ServicoId }, servico);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateServicoDto dto)
        {
            var servico = await _context.Servicos.FindAsync(id);

            if (servico == null)
                return NotFound();

            servico.NomeServico = dto.NomeServico;
            servico.AreaServico = dto.AreaServico;
            servico.Mostrar = dto.Mostrar;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var servico = await _context.Servicos.FindAsync(id);
            if (servico == null)
                return NotFound();

            _context.Servicos.Remove(servico);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}