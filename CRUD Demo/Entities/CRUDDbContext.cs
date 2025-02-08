using System.Text.Json;
using Microsoft.Data.SqlClient;
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
    public int sp_AddPerson(Person person)
    {
        SqlParameter[] sqlParameters = new SqlParameter[]{
            new SqlParameter("@PersonId", person.PersonId),
            new SqlParameter("@PersonName",person.PersonName),
            new SqlParameter("@Email",person.Email),
            new SqlParameter("@DateOfBirth",person.DateOfBirth),
            new SqlParameter("@Gender",person.Gender),
            new SqlParameter("@CountryId",person.CountryId),
            new SqlParameter("@Address",person.Address),
            new SqlParameter("@ReveiveNewsLetters",person.ReveiveNewsLetters)
        };
        string sp = @"Exec dbo.AddPerson @PersonId, @PersonName, @Email, @DateofBirth, @Gender, @CountryId, @Address, @ReveiveNewsLetters,";
        return Database.ExecuteSqlRaw($"{sp} {sqlParameters}");
    }
}

// Seed Data :- It adds initial data ( initial rows ) in tables, when the database is newly created