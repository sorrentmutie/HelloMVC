using DemoCorso.Core.Interfaces;
using DemoCorso.Data.Models;
using HelloMVC.Configurations;
using HelloMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace HelloMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Category, int> repository;
        private readonly IOptions<MyKeyOptions> options;
        private readonly IOptions<TopItemOptions> topItemOptions;

        public HomeController(ILogger<HomeController> logger,
            IRepository<Category, int> repository,
            IOptions<MyKeyOptions> options,
            IOptionsSnapshot<TopItemOptions> topItemOptions)
        {
            _logger = logger;
            this.repository = repository;
            this.options = options;
            this.topItemOptions = topItemOptions;
            var x = topItemOptions.Get(TopItemOptions.Month);
            var y = x.Model;
            try
            {
                var z = options.Value.Number;
            }
            catch (OptionsValidationException ex)
            {

                foreach (var failure in ex.Failures)
                {
                    _logger.LogError(failure);
                };
            }
            
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
