using Microsoft.EntityFrameworkCore;

namespace CerealAPI;

public class CerealDbContext : DbContext
{
    public CerealDbContext(DbContextOptions<CerealDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<CerealClass> Cereals { get; set; }
    
}