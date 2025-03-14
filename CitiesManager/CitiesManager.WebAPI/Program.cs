using CitiesManager.WebAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddEndpointsApiExplorer(); // generated description for all endpoints
builder.Services.AddSwaggerGen();   // Generates open API specification

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseSwagger();   // creates endpoints for Swagger.json
app.UseSwaggerUI(); // creates Swagger UI for testing all web API endpoint

app.UseHsts();          // force browsers to use Http 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();