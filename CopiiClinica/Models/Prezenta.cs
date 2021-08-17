using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CopiiClinica.Models {
  public class Prezenta {
    [Key]
    public int ID { get; set; }
    [Required]
    public DateTime Data { get; set; }
    [Required]
    [ForeignKey("Copil")]
    public int CopilID { get; set; }
    public Copil Copil { get; set; }
    [Required]
    public bool Prezent { get; set; }
  }
}
