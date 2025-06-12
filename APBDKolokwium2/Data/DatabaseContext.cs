using Microsoft.EntityFrameworkCore;

namespace APBDKolokwium2.Data;

public class DatabaseContext : DbContext
{
    //public DbSet...
    
    
    protected DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}