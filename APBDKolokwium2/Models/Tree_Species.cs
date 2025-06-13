using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDKolokwium2.Models;

[Table("Tree_Species")]
public class Tree_Species
{
    [Key]
    public int SpeciesId { get; set; }
    [MaxLength(100)]
    public string LatinName { get; set; }
    public int GrowthTimeInYears { get; set; }
    public ICollection<Seedling_Batch> SeedlingBatches { get; set; }
}