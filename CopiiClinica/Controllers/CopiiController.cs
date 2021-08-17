using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CopiiClinica.Models;

namespace CopiiClinica.Controllers {
  [Route("api/Copil")]
  [ApiController]
  public class CopiiController : Controller {
    private readonly ApplicationDbContext _context;

    public CopiiController(ApplicationDbContext context) {
      _context = context;
    }

    // GET: api/Copii
    [HttpGet]
    public async Task<ActionResult> GetCopii() {
      return Json(new { data =await _context.Copii.ToListAsync() });
    }

    // GET: api/Copii/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Copil>> GetCopil(int id) {
      var copil = await _context.Copii.FindAsync(id);

      if (copil == null) {
        return NotFound();
      }

      return copil;
    }

    // PUT: api/Copii/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCopil(int id, Copil copil) {
      if (id != copil.ID) {
        return BadRequest();
      }

      _context.Entry(copil).State = EntityState.Modified;

      try {
        await _context.SaveChangesAsync();
      } catch (DbUpdateConcurrencyException) {
        if (!CopilExists(id)) {
          return NotFound();
        } else {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Copii
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Copil>> PostCopil(Copil copil) {
      _context.Copii.Add(copil);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetCopil", new { id = copil.ID }, copil);
    }

    // DELETE: api/Copii/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCopil(int id) {
      var copil = await _context.Copii.FindAsync(id);
      if (copil == null) {
        return NotFound();
      }

      _context.Copii.Remove(copil);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool CopilExists(int id) {
      return _context.Copii.Any(e => e.ID == id);
    }
  }
}
