using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CopiiClinica.Models;

namespace CopiiClinica.Pages.Copii
{
    public class DetailsModel : PageModel
    {
        private readonly CopiiClinica.Models.ApplicationDbContext _context;

        public DetailsModel(CopiiClinica.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public Copil Copil { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Copil = await _context.Copii.FirstOrDefaultAsync(m => m.ID == id);

            if (Copil == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
