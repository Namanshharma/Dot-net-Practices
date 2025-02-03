using Entities;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddScoped<IPersonsService, PersonsService>();
builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddDbContext<DatabaseDbContext>(x =>
{
    x.UseSqlServer();   // specifing that in this we are using SQL server
});                     // by using this we are registering our DbContext ( Database ) in IOC container 


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHsts();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();