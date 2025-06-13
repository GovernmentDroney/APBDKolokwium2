using APBDKolokwium2.Data;
using APBDKolokwium2.DTOs;
using APBDKolokwium2.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace APBDKolokwium2.Services;

public class NurseryService : INurseryService
{
    private readonly DatabaseContext _context;

    public NurseryService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<GetNurseryDTO> GetNursery(int id)
    {
        var getNursery = await _context.Nurseries.Where(e => e.NurseryId == id)
            .Select(e => new GetNurseryDTO
            {
                NurseryId = e.NurseryId,
                Name = e.Name,
                EstalishedDate = e.EstablishedDate,
                Batches = e.SeedlingBatches.Select(a => new BatchDTO
                {
                    BatchId = a.BatchId,
                    Quantity = a.Quantity,
                    SownDate = a.SownDate,
                    ReadyDate = a.ReadyDate ?? null,
                    Species = new SpeciesDTO
                    {
                        LatinName = a.Species.LatinName,
                        GrowthTimeInYears = a.Species.GrowthTimeInYears,
                    },
                    Responsibles = a.Responsibles.Select(b => new ResponsibleDTO
                    {
                        FirstName = b.Employee.FirstName,
                        LastName = b.Employee.LastName,
                        Role = b.Role
                    }).ToList()
                }).ToList()
            }).FirstOrDefaultAsync();
        if (getNursery == null)
        {
            throw new NotFoundException();
        }
        return getNursery;
    }
}