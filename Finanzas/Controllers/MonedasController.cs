// Finanzas/Controllers/MonedasController.cs
using Finanzas.Data;
using Finanzas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonedasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MonedasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/monedas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moneda>>> GetMonedas()
        {
            return await _context.Monedas.ToListAsync();
        }

        // GET: api/monedas/BOB
        [HttpGet("{id}")]
        public async Task<ActionResult<Moneda>> GetMoneda(string id)
        {
            var moneda = await _context.Monedas.FindAsync(id.ToUpper());

            if (moneda == null)
                return NotFound(new { mensaje = $"No se encontró la moneda con ID '{id}'." });

            return moneda;
        }

        // POST: api/monedas
        [HttpPost]
        public async Task<ActionResult<Moneda>> PostMoneda(Moneda moneda)
        {
            moneda.Id = moneda.Id.Trim().ToUpper();

            if (await _context.Monedas.AnyAsync(m => m.Id == moneda.Id))
                return Conflict(new { mensaje = $"La moneda con ID '{moneda.Id}' ya existe." });

            _context.Monedas.Add(moneda);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMoneda), new { id = moneda.Id }, moneda);
        }

        // PUT: api/monedas/BOB
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoneda(string id, Moneda moneda)
        {
            var idNormalizado = id.Trim().ToUpper();

            if (idNormalizado != moneda.Id.Trim().ToUpper())
                return BadRequest(new { mensaje = "El ID de la URL no coincide con el ID del cuerpo." });

            var existente = await _context.Monedas.FindAsync(idNormalizado);
            if (existente == null)
                return NotFound(new { mensaje = $"No se encontró la moneda con ID '{idNormalizado}'." });

            existente.Nombre = moneda.Nombre;
            existente.Simbolo = moneda.Simbolo;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/monedas/BOB
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoneda(string id)
        {
            var moneda = await _context.Monedas.FindAsync(id.Trim().ToUpper());
            if (moneda == null)
                return NotFound(new { mensaje = $"No se encontró la moneda con ID '{id}'." });

            _context.Monedas.Remove(moneda);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}