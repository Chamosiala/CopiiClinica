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
  public class CreateModel : PageModel {
    private readonly CopiiClinica.Models.ApplicationDbContext _context;

    public CreateModel(CopiiClinica.Models.ApplicationDbContext context) {
      _context = context;
    }

    public IActionResult OnGet() {
      return Page();
    }

    [BindProperty]
    public Prezenta Prezenta { get; set; }
    [BindProperty]
    public bool IsCopilIDValid { get; set; } = true;

    public async Task<IActionResult> OnPostAsync() {
      Copil CopilFromDb = await _context.Copii.FindAsync(Prezenta.CopilID);
      Prezenta.Copil = CopilFromDb;

      if (!ModelState.IsValid || CopilFromDb == null) {
        IsCopilIDValid = false;
        return Page();
      }

      _context.Prezente.Add(Prezenta);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
