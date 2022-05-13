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
    public class HomesController : ControllerBase
    {
        private readonly DataContext _context;

        public HomesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Homes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Home>>> GetHomes()
        {
            return await _context.Homes.ToListAsync();
        }

        // GET: api/Homes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Home>> GetHomes(int id)
        {
            var homes = await _context.Homes.FindAsync(id);

            if (homes == null)
            {
                return NotFound();
            }

            return homes;
        }

        // PUT: api/Homes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomes(int id, Home homes)
        {
            if (id != homes.Id)
            {
                return BadRequest();
            }

            _context.Entry(homes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomesExists(id))
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

        // POST: api/Homes
        [HttpPost]
        public async Task<ActionResult<Home>> PostHomes(Home homes)
        {
            _context.Homes.Add(homes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHomes", new { id = homes.Id }, homes);
        }

        // DELETE: api/Homes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomes(int id)
        {
            var homes = await _context.Homes.FindAsync(id);
            if (homes == null)
            {
                return NotFound();
            }

            _context.Homes.Remove(homes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HomesExists(int id)
        {
            return _context.Homes.Any(e => e.Id == id);
        }
    }
}
