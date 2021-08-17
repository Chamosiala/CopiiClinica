using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CopiiClinica.Models;

namespace CopiiClinica.Pages.Copii
{
    public class CreateModel : PageModel
    {
        private readonly CopiiClinica.Models.ApplicationDbContext _context;

        public CreateModel(CopiiClinica.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Copil Copil { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Copii.Add(Copil);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
