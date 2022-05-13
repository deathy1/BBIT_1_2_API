#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BBIT_2_API;
using BBIT_2_API.Models.Data;

namespace BBIT_2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly DataContext _context;

        public ApartmentsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Apartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apartment>>> GetApartments()
        {
            return await _context.Apartments.ToListAsync();
        }

        // GET: api/Apartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Apartment>> GetApartments(int id)
        {
            var apartments = await _context.Apartments.FindAsync(id);

            if (apartments == null)
            {
                return NotFound();
            }

            return apartments;
        }

        // PUT: api/Apartments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApartments(int id, Apartment apartments)
        {
            if (id != apartments.Id)
            {
                return BadRequest();
            }

            _context.Entry(apartments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentsExists(id))
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

        // POST: api/Apartments
        [HttpPost]
        public async Task<ActionResult<Apartment>> PostApartments(Apartment apartments)
        {
            _context.Apartments.Add(apartments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApartments", new { id = apartments.Id }, apartments);
        }

        // DELETE: api/Apartments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartments(int id)
        {
            var apartments = await _context.Apartments.FindAsync(id);
            if (apartments == null)
            {
                return NotFound();
            }

            _context.Apartments.Remove(apartments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApartmentsExists(int id)
        {
            return _context.Apartments.Any(e => e.Id == id);
        }
    }
}
