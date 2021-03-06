using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CopiiClinica.Models;

namespace CopiiClinica.Pages.Prezente {
  public class EditModel : PageModel {
    private readonly CopiiClinica.Models.ApplicationDbContext _context;

    public EditModel(CopiiClinica.Models.ApplicationDbContext context) {
      _context = context;
    }

    [BindProperty]
    public Prezenta Prezenta { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id) {
      if (id == null) {
        return NotFound();
      }

      Prezenta = await _context.Prezente.FirstOrDefaultAsync(m => m.ID == id);

      if (Prezenta == null) {
        return NotFound();
      }
      return Page();
    }

    public async Task<IActionResult> OnPostAsync() {
      if (!ModelState.IsValid) {
        return Page();
      }

      _context.Attach(Prezenta).State = EntityState.Modified;

      try {
        await _context.SaveChangesAsync();
      } catch (DbUpdateConcurrencyException) {
        if (!PrezentaExists(Prezenta.ID)) {
          return NotFound();
        } else {
          throw;
        }
      }

      return RedirectToPage("./Index");
    }

    private bool PrezentaExists(int id) {
      return _context.Prezente.Any(e => e.ID == id);
    }
  }
}
