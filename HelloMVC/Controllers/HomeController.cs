using DemoCorso.Core.Interfaces;
using DemoCorso.Data.Models;
using HelloMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HelloMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Category, int> repository;

        public HomeController(ILogger<HomeController> logger,
            IRepository<Category, int> repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        public async Task<IActionResult?> Index()
        {
            if (repository is null) return null;
            var categories =  repository.Get();
            if (categories is null) return null;

            var orderedCategories = await categories
                .OrderBy(x => x.CategoryName)
                .ToListAsync();

            await repository.CreateAsync(new Category
            { CategoryName = "Nuova Categoria", Description = "Descrizione" });


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
