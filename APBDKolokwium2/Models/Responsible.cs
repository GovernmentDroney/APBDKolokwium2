using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBDKolokwium2.Models;

[Table("Responsible")]
[PrimaryKey(nameof(BatchId),nameof(EmployeeId))]
public class Responsible
{
   [ForeignKey("BatchId")] 
   public int BatchId { get; set; }
   public Seedling_Batch Batch { get; set; }
   
   [ForeignKey("EmployeeId")]
   public int EmployeeId { get; set; }
   public Employee Employee { get; set; }
   
   [MaxLength(100)]
   public string Role { get; set; }
}