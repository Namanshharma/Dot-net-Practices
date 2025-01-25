using InterfaceClassLibrary;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// builder.Services.Add(new ServiceDescriptor(typeof(ICityServices), typeof(CitiesService), ServiceLifetime.Transient));
builder.Services.AddTransient<ICityServices, CitiesService>();

var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();

// DIP ( DEPENDENCY INVERSION PRINCIPLE ) <<---- It says that the Higher level class must not be dependent on the lower level class instead both must depend upon ABSTRACTION.
// IOC ( Inversion of Control ) <---- It is a design pattern which suggest IOC container for implmentation of DIP
// BUILDER.SERVICES is our IOC container
// DI <<---- It is a design pattern which is technique for achieving "IOC" between client and their dependencies
// Service Lifetime indicates when a new object of service has to be created by IOC / DI container.
// Transient == created Per injection ; but destroyed -  at the end of scope not at the end of class 
// Scoped == created Per browser request    ; destroyed - at the end of scope
// Singleton == created For entire application lifetime     ; destroyed - at the shutdown of application