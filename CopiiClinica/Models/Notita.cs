using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CopiiClinica.Models {
  public class Notita {
    [Key]
    public int ID { get; set; }
    [Required]
    [ForeignKey("Prezenta")]
    public int PrezentaID { get; set; }
    public Prezenta Prezenta { get; set; }
    [Required]
    public string Interval { get; set; }
    [Required]
    public string Mesaj { get; set; }
  }
}
