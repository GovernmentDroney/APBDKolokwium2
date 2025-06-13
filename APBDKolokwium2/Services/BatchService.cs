using APBDKolokwium2.Data;
using APBDKolokwium2.DTOs;
using APBDKolokwium2.Exceptions;
using APBDKolokwium2.Models;

namespace APBDKolokwium2.Services;

public class BatchService : IBatchService
{
    private readonly DatabaseContext _context;

    public BatchService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task PostBatch(PostBatchDTO batch)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var SpeciesCheck = _context.Tree_Species.FirstOrDefault(e => e.LatinName.Equals(batch.Species));
            if (SpeciesCheck == null)
            {
                throw new NotFoundException();
            }
            
             var Nurserycheck = _context.Nurseries.FirstOrDefault(e => e.Name.Equals(batch.Nursery));
             if (Nurserycheck == null)
             {
                 throw new NotFoundException();
             }

             foreach (var employee in batch.Responsibles)
             {
                 var EmployeeCheck = _context.Employees.FirstOrDefault(e=>e.EmployeeId.Equals(employee.EmployeeId));
                 if (EmployeeCheck == null)
                 {
                     throw new NotFoundException();
                 }
             }
             // var getBatchId = _context.Seedling_Batches.FirstOrDefault(e=>e.)
             List<Responsible> responsibles = new List<Responsible>();
             foreach (var employee in batch.Responsibles)
             {
                 var responsibleEmployee = new Responsible()
                 {
                     // BatchId = 
                     EmployeeId = employee.EmployeeId,
                     Role = employee.Role,
                 };
                 responsibles.Add(responsibleEmployee);
             }

             var newBatch = new Seedling_Batch()
             {
                 NurseryId = Nurserycheck.NurseryId,
                 SpeciesId = SpeciesCheck.SpeciesId,
                 Quantity = batch.Quantity,
                 SownDate = DateTime.Now,
                 Responsibles = responsibles
             };
             await _context.Seedling_Batches.AddAsync(newBatch);
            
             await _context.SaveChangesAsync();
            
             await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}