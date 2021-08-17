using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CopiiClinica.Models;

namespace CopiiClinica.Pages.Prezente {
  public class IndexModel : PageModel {
    private readonly CopiiClinica.Models.ApplicationDbContext _context;

    public IndexModel(CopiiClinica.Models.ApplicationDbContext context) {
      _context = context;
    }

    public IList<Prezenta> ListaPrezente { get; set; }
    public IList<Copil> ListaCopii { get; set; }
    public IList<Copil> ListaCopiiFiltrati { get; set; }

    public async Task OnGetAsync() {
      ListaPrezente = await _context.Prezente.ToListAsync();
      ListaCopii = await _context.Copii.ToListAsync();
      
      
      //if (ListaPrezente.Count > 0)
      //  foreach (Prezenta prezenta in ListaPrezente) {
      //    Copil CopilFiltrat = await _context.Copii.FirstOrDefaultAsync(x => x.ID == prezenta.CopilID);
      //    ListaCopiiFiltrati.Add(CopilFiltrat);
      //  }
    }
  }
}
