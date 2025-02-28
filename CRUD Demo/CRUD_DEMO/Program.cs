using CRUD_DEMO.Filters.ActionFilters;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using RepositoryContracts;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(x => x.Filters.Add<PersonListActionFilter>()); // in this way we can declare the Global Level Filter
builder.Services.AddControllers(x => x.Filters.Add<PersonListActionFilter>());          // in this way we can declare the Global Level Filter but by declaring Action Filter like this
// we can not be able to pass the Arguments

builder.Services.AddControllers(x =>
{
    var logger = builder?.Services?.BuildServiceProvider()?.GetRequiredService<ILogger<PersonListActionFilter>>();
    if (logger != null)
        x.Filters.Add(new PersonListActionFilter(logger, "", ""));
});

builder.Services.AddScoped<IPersonsRepository, PersonsRepository>();
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddScoped<IPersonsService, PersonsService>();
builder.Services.AddScoped<ICountriesService, CountriesService>();

builder.Services.AddDbContext<CRUDDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));   // specifing that in this we are using SQL server
});                // by using this we are registering our DbContext ( Database ) in IOC container 

builder.Services.AddCors(x =>
{
    x.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();              // here we have configured the CORD policy
    });
});

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
// builder.Services.AddRateLimiter(x => x.GlobalLimiter = 10);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpLogging();
app.UseHsts();
app.UseStaticFiles();
app.UseCors();                                      // here we have added the CORS in our pipeline
app.UseRouting();
app.MapControllers();

app.Run();