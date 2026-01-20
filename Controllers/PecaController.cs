using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SsiApi.Data;
using SsiApi.DTOs;
using SsiApi.Models;

namespace SsiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PecaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PecaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Pecas.ToListAsync());
        }
    }
}