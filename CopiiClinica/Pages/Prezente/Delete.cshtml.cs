using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CopiiClinica.Models;

namespace CopiiClinica.Pages.Prezente
{
    public class DeleteModel : PageModel
    {
        private readonly CopiiClinica.Models.ApplicationDbContext _context;

        public DeleteModel(CopiiClinica.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Prezenta Prezenta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prezenta = await _context.Prezente.FirstOrDefaultAsync(m => m.ID == id);

            if (Prezenta == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prezenta = await _context.Prezente.FindAsync(id);

            if (Prezenta != null)
            {
                _context.Prezente.Remove(Prezenta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
