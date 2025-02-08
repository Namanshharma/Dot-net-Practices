using System.Text.Json;
using Microsoft.EntityFrameworkCore;
namespace Entities;
public class CRUDDbContext : DbContext
{
    public CRUDDbContext(DbContextOptions<CRUDDbContext> dbContextOptions) : base(dbContextOptions) { }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Person> Persons { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Country>().ToTable("Countires");
        modelBuilder.Entity<Person>().ToTable("Persons");

        //seed data from JSON file
        string CountriesJson = File.ReadAllText("Countries.json");
        List<Country>? countriesList = JsonSerializer.Deserialize<List<Country>>(CountriesJson);
        if (countriesList != null)
        {
            foreach (Country country in countriesList)
            {
                modelBuilder.Entity<Country>().HasData(country);
            }
        }
        string PersonJson = File.ReadAllText("Persons.json");
        List<Person>? personsList = JsonSerializer.Deserialize<List<Person>>(PersonJson);
        if (personsList != null)
        {
            foreach (Person person in personsList)
            {
                modelBuilder.Entity<Person>().HasData(person);
            }
        }
    }
    public List<Person> sp_GetAllPersons()
    {
        return Persons.FromSqlRaw("Execute dbo.GetAllPersons").ToList();
    }
}

// Seed Data :- It adds initial data ( initial rows ) in tables, when the database is newly created