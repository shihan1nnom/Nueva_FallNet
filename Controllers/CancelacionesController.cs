using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFall.Model;

namespace PruebaFall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancelacionesController : ControllerBase
    {
        private readonly ContextoBD _context;

        public CancelacionesController(ContextoBD context)
        {
            _context = context;
        }

        // GET: api/Cancelaciones
        [HttpGet]
        public IEnumerable<List<Dato>> GetCancelaciones()
        {
            List<Dato> datos = new List<Dato>();
            List<Cancelacion> cancelaciones = new List<Cancelacion>();
            var consulta = from dato in datos
                join cancelacion in cancelaciones on dato.Id equals cancelacion.DatoId
                select datos;
            return consulta;
        }

        // GET: api/Cancelaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cancelacion>> GetCancelacion(long id)
        {
            var cancelacion = await _context.Cancelaciones.FindAsync(id);

            if (cancelacion == null)
            {
                return NotFound();
            }

            return cancelacion;
        }

        // PUT: api/Cancelaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancelacion(long id, Cancelacion cancelacion)
        {
            if (id != cancelacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(cancelacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CancelacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cancelaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cancelacion>> PostCancelacion(Cancelacion cancelacion)
        {
            _context.Cancelaciones.Add(cancelacion);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCancelacion", new { id = cancelacion.Id }, cancelacion);
            return CreatedAtAction(nameof(GetCancelacion), new { id = cancelacion.Id }, cancelacion);
        }

        // DELETE: api/Cancelaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancelacion(long id)
        {
            var cancelacion = await _context.Cancelaciones.FindAsync(id);
            if (cancelacion == null)
            {
                return NotFound();
            }

            _context.Cancelaciones.Remove(cancelacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CancelacionExists(long id)
        {
            return _context.Cancelaciones.Any(e => e.Id == id);
        }
    }
}
