using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CopiiClinica.Models;
using Microsoft.EntityFrameworkCore;

namespace CopiiClinica.Pages.Prezente {
  public class NewNoteModel : PageModel {
    private readonly CopiiClinica.Models.ApplicationDbContext _context;

    public NewNoteModel(CopiiClinica.Models.ApplicationDbContext context) {
      _context = context;
    }
    
    [BindProperty]
    public Prezenta Prezenta { get; set; }
    [BindProperty]
    public Notita Notita { get; set; }
    public int ID { get; set; }

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

    public async Task<IActionResult> OnPostAsync(int id) {
      Notita.PrezentaID = id;
      Prezenta = await _context.Prezente.FirstOrDefaultAsync(u => u.ID == Notita.PrezentaID);
      Notita.Prezenta = Prezenta;

      if (!ModelState.IsValid)
        return Page();

      _context.Notite.Add(Notita);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
