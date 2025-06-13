using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDKolokwium2.Models;

[Table("Nursery")]
public class Nursery
{
    [Key]
    public int NurseryId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }
    public ICollection<Seedling_Batch> SeedlingBatches { get; set; }
}