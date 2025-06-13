using APBDKolokwium2.Models;

namespace APBDKolokwium2.DTOs;

public class PostBatchDTO
{
    public int Quantity { get; set; }
    public string Species { get; set; }
    public string Nursery { get; set; }
    public List<PostResponsibleDTO> Responsibles { get; set; }
}

public class PostResponsibleDTO
{
    public int EmployeeId { get; set; }
    public string Role { get; set; }
}