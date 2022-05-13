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
    public class ResidentsController : ControllerBase
    {
        private readonly DataContext _context;

        public ResidentsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Residents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resident>>> GetResidents()
        {
            return await _context.Residents.ToListAsync();
        }

        // GET: api/Residents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resident>> GetResidents(int id)
        {
            var residents = await _context.Residents.FindAsync(id);

            if (residents == null)
            {
                return NotFound();
            }

            return residents;
        }

        // PUT: api/Residents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResidents(int id, Resident residents)
        {
            if (id != residents.Id)
            {
                return BadRequest();
            }

            _context.Entry(residents).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidentsExists(id))
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
        
        // POST: api/Residents
        [HttpPost]
        public async Task<ActionResult<Resident>> PostResidents(Resident residents)
        {
            _context.Residents.Add(residents);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResidents", new { id = residents.Id }, residents);
        }

        // DELETE: api/Residents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResidents(int id)
        {
            var residents = await _context.Residents.FindAsync(id);
            if (residents == null)
            {
                return NotFound();
            }

            _context.Residents.Remove(residents);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResidentsExists(int id)
        {
            return _context.Residents.Any(e => e.Id == id);
        }
    }
}
