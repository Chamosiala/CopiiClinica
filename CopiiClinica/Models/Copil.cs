using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CopiiClinica.Models {
  public class Copil {
    [Key]
    public int ID { get; set; }

    [Required]
    public string Nume { get; set; }
    [Required]
    public string Prenume { get; set; }

    public int Varsta { get; set; }
  }
}
