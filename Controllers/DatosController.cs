using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFall.Model;

namespace PruebaFall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosController : ControllerBase
    {
        private readonly ContextoBD _context;

        public DatosController(ContextoBD context)
        {
            _context = context;
        }

        // GET: api/Datos
        [HttpGet]
        public IQueryable GetDatos()
        {
            var datos =  _context.Datos;
            var cancelaciones = _context.Cancelaciones;
            var consulta = from c in cancelaciones
                //where cancelacion.f12 == dato.f12
                select new { cc = c._f12.cc, oc = c.oc, f12 = c.f12, sku = c._f12.sku, n_entrega = "X", comentario = "Cancelacion", estadof12 = "Y" };
            return consulta;
        }

        // GET: api/Datos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dato>> GetDato(long id)
        {
            var dato = await _context.Datos.FindAsync(id);

            if (dato == null)
            {
                return NotFound();
            }

            return dato;
        }

        // PUT: api/Datos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDato(long id, Dato dato)
        {
            if (id != dato.Id)
            {
                return BadRequest();
            }

            _context.Entry(dato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatoExists(id))
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

        // POST: api/Datos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dato>> PostDato(Dato dato)
        {
            _context.Datos.Add(dato);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDato), new { id = dato.Id }, dato);
        }

        // DELETE: api/Datos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDato(long id)
        {
            var dato = await _context.Datos.FindAsync(id);
            if (dato == null)
            {
                return NotFound();
            }

            _context.Datos.Remove(dato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DatoExists(long id)
        {
            return _context.Datos.Any(e => e.Id == id);
        }
    }
}
