using DemoCorso.Core.Eventi;
using DemoCorso.Data.Models;
using DemoCorso.Infrastructure.Northwind.Categorie;
using HelloMVC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEventi, GestoreStaticoEventi>();
builder.Services.AddDbContext<NorthwindContext>(opzioni =>
{
    opzioni.UseSqlServer(connectionString);
});
builder.Services.AddScoped<ICategorie, ServizioCategorie>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "special",
//    pattern: "special/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    "cucina",
    "cucina/{nome?}",
    new { controller =  "Cucina", action =  "Ricerca"});


app.Run();

