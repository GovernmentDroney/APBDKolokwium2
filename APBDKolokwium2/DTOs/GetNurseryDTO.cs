using APBDKolokwium2.Models;

namespace APBDKolokwium2.DTOs;

public class GetNurseryDTO
{
    public int NurseryId { get; set; }
    public string Name { get; set; }
    public DateTime EstalishedDate { get; set; }
    public List<BatchDTO> Batches { get; set; }
}

public class BatchDTO
{
    public int BatchId { get; set; }
    public int Quantity { get; set; }
    public DateTime SownDate { get; set; }
    public DateTime? ReadyDate { get; set; }
    public SpeciesDTO Species { get; set; }
    public List<ResponsibleDTO> Responsibles { get; set; }
}

public class SpeciesDTO
{
    public string LatinName { get; set; }
    public int GrowthTimeInYears { get; set; }
}

public class ResponsibleDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
}