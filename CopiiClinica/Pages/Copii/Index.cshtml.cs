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
    public class IndexModel : PageModel
    {
        private readonly CopiiClinica.Models.ApplicationDbContext _context;

        public IndexModel(CopiiClinica.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Copil> Copil { get;set; }

        public async Task OnGetAsync()
        {
            Copil = await _context.Copii.ToListAsync();
        }
    }
}
