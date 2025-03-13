using CitiesManager.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CitiesManager.WebAPI.DatabaseContext;
public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions options) : base(options) { }
    protected ApplicationDBContext() { }
    public virtual DbSet<City> Cities { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<City>().HasData(new City() = { CityId = Guid.Parse("b19feae6-e804-4765-8234-6505dfa1a74c"), CityName = "Amritsar" });

        modelBuilder.Entity<City>().HasData(new City() = { CityId = Guid.Parse("b4c9a780-15dd-4395-9246-e10fba41a9f4"), CityName = "Chandigarh" });
    }
}