var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHsts();          // force browsers to use Http 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();