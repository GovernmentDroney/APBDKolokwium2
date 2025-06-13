using APBDKolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBDKolokwium2.Data;

public class DatabaseContext : DbContext
{
   
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Nursery> Nurseries { get; set; }
    public DbSet<Tree_Species> Tree_Species { get; set; }
    public DbSet<Seedling_Batch> Seedling_Batches { get; set; }
    public DbSet<Responsible> Responsibles { get; set; }
    
    protected DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(new List<Employee>
        {
            new Employee()
                { EmployeeId = 1, FirstName = "Jan", LastName = "Kowalski", HireDate = DateTime.Parse("2023-01-01"), }
        });
        modelBuilder.Entity<Nursery>().HasData(new List<Nursery>
        {
            new Nursery() { NurseryId = 1, Name = "Green", EstablishedDate = DateTime.Parse("2000-01-01") },
        });
        modelBuilder.Entity<Tree_Species>().HasData(new List<Tree_Species>
        {
            new Tree_Species() { SpeciesId = 1, LatinName = "bog wie co", GrowthTimeInYears = 3 }
        });
        modelBuilder.Entity<Seedling_Batch>().HasData(new List<Seedling_Batch>
        {
            new Seedling_Batch()
                { BatchId = 1, NurseryId = 1, SpeciesId = 1, Quantity = 56, SownDate = DateTime.Parse("2025-01-01"), ReadyDate = DateTime.Parse("2025-01-02") },
        });

        modelBuilder.Entity<Responsible>().HasData(new List<Responsible>
        {
            new Responsible() {BatchId = 1,EmployeeId = 1, Role = "water"}
        });
    }
}