using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopiiClinica.Models {
  public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
    }

    public DbSet<Copil> Copii { get; set; }
    public DbSet<Prezenta> Prezente { get; set; }
    public DbSet<Notita> Notite { get; set; }
  }
}
