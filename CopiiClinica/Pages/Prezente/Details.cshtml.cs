using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CopiiClinica.Models;

namespace CopiiClinica.Pages.Prezente {
  public class DetailsModel : PageModel {
    private readonly CopiiClinica.Models.ApplicationDbContext _context;

    public DetailsModel(CopiiClinica.Models.ApplicationDbContext context) {
      _context = context;
    }

    public Prezenta Prezenta { get; set; }
    public Copil Copil { get; set; }
    public IList<Notita> ListaNotite { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id) {
      if (id == null) {
        return NotFound();
      }

      ListaNotite = await _context.Notite.Where(m => m.PrezentaID == id).ToListAsync();

      Prezenta = await _context.Prezente.FirstOrDefaultAsync(m => m.ID == id);
      Copil = await _context.Copii.FirstOrDefaultAsync(m => m.ID == Prezenta.CopilID);

      if (Prezenta == null) {
        return NotFound();
      }
      return Page();
    }
  }
}
