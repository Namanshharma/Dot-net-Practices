using InterfaceClassLibrary;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// builder.Services.Add(new ServiceDescriptor(typeof(ICityServices), typeof(CitiesService), ServiceLifetime.Transient));
builder.Services.AddTransient<ICityServices, CitiesService>();
builder.Services.AddHttpClient();                                           // to make 3rd party calls

var app = builder.Build();

// var value = app.Configuration["MyKey"];             // Configuration related thing

// if (app.Environment.IsDevelopment())            // Environment related things
// {
//     app.UseDeveloperExceptionPage();
// }

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

// After this the next thing is ENVIRONMENT :- by using app.Environment property we can access the Environment related things in Program.cs file
// Similarly in the controllers :- we can use IWEBHOSTENVIRONMENT class to access the Environment related things in Contorller class becoz in program.cs file app.Environment comes from that 
// same class ( IWEBHOSTENVIRONMENT )
// All of the ENVIRONMENT related things are present in LaunchSetting.json file but while deploying the application we will not deploy this LaunchSetting.json file. So in that case, we will
// use the Powershell commands in PROD server to run the application. Cd into main project.csproj file directory and then we can run the dot net application through command and also we can
// disable the launchsetting.json file in prod server. So that, our app will automatically take it as PROD server bcoz if Launch setting file is not present then dot net app will automatically
// consider it as a prod server.

// After this next step is Configuration :- In controller , program.cs , in services or in anyother file we can use IConfiguration class to pick get the values from AppSetting.json file
// Through, IConfiguration class we can access the key like 2-d array or we can use GetValue<type>("KeyName") to access the key. Also, we can use the GetValue<>() method to give the default
// value like if the mentioned key is not present in then it will give the Default value. GetValue<>(keyname , default value) <--- Default value like "Key is not present"
// Similarly, we have one method which will get the whole JSON section from appSettings.json file. Similarly, we can register the one section from AppSetting.json as a Service.

// After this next step is HttpClient :- Sometimes, we need to make 3rd party calls from our dot net code and for that we require HttpClient and to use that we need IHttpClientFactory class