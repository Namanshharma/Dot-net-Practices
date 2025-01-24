using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.DBContext;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext() { }
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

    public virtual DbSet<CityModel> DbCities { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = Guid.Parse("3004835f-35ca-4b53-b7c1-fd2da8c37de7"), CityName = "Amritsar" });
        modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = Guid.Parse("2af7b353-1f42-4255-817f-27422419a1ac"), CityName = "Jalandhar" });
    }
}