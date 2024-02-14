using DemoCorso.Core.Eventi;
using DemoCorso.Core.Interfaces;
using DemoCorso.Data.Models;
using DemoCorso.Data.Services;
using DemoCorso.Infrastructure.Northwind.Categorie;
using HelloMVC.Configurations;
using HelloMVC.Data;
using HelloMVC.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEventi, GestoreStaticoEventi>();

builder.Services.AddDbContext<NorthwindContext>(opzioni =>
{
    opzioni.UseSqlServer(connectionString);
});
builder.Services.AddDbContext<SchoolDbContext>(opzioni =>
{
    opzioni.UseSqlServer(builder.Configuration.GetConnectionString("SchoolConnection"));
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.TryAddScoped<DbContext, NorthwindContext>();
builder.Services.AddScoped<ICategorie, ServizioCategorie>();
builder.Services.AddScoped<IRepository<Category, int>, 
    NorthwindRepository<Category, int>>();

//builder.Services.Configure<MyKeyOptions>
//    (builder.Configuration.GetSection(MyKeyOptions.MyKey));
builder.Services.AddOptions<MyKeyOptions>()
    .Bind(builder.Configuration.GetSection(MyKeyOptions.MyKey))
    .ValidateDataAnnotations();

builder.Services.Configure<TopItemOptions>(TopItemOptions.Month,
     builder.Configuration.GetSection("TopItem:Month"));

builder.Services.Configure<TopItemOptions>(TopItemOptions.Year,
     builder.Configuration.GetSection("TopItem:Year"));

builder.Services.AddMemoryCache();

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

