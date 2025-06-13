using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDKolokwium2.Models;
[Table("Seeding_Batch")]
public class Seedling_Batch
{
    [Key]
    public int BatchId { get; set; }
    [ForeignKey("NurseryId")]
    public int NurseryId { get; set; }
    public Nursery Nursery { get; set; }
    
    [ForeignKey("SpeciesId")]
    public int SpeciesId { get; set; }
    public Tree_Species Species { get; set; }
    
    public int Quantity { get; set; }
    public DateTime SownDate { get; set; }
    public DateTime? ReadyDate { get; set; }
    
    public ICollection<Responsible> Responsibles { get; set; }
}