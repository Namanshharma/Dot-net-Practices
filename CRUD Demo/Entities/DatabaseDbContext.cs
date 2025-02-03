using Microsoft.EntityFrameworkCore;
namespace Entities;
public class DatabaseDbContext : DbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<Person> Persons { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Country>().ToTable("Countires");
        modelBuilder.Entity<Person>().ToTable("Persons");
    }
}