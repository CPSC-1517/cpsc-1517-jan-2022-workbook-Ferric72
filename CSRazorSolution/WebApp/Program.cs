#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using WestWindSystem;
#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//setup the connection string service for the application.
//1) retrieve the connection string information from your appsetting.json.
var connectionString = builder.Configuration.GetConnectionString("WWDB");

//2) register any "services" you wish to use.
//      in our solution our services will be created (coded) in the class library WestWindSystem.
//      one of these services will be the setup of the database context connection.
//      other services will be created as the application requires.

//this setup can be done here, locally.
//this setup can also be done elsewhere and called from this location ****
builder.Services.WWBackendDependencies(options => options.UseSqlServer(connectionString));

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
