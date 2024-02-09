using DemoCorso.Core.Northwind.ViewModels;
using DemoCorso.Data.Models;
using DemoCorso.Infrastructure.Northwind.Categorie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelloMVC.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ICategorie servizioCategorie;

        // private readonly NorthwindContext northwindContext;

        public CategorieController(ICategorie servizioCategorie)
        {
            this.servizioCategorie = servizioCategorie;
            // this.northwindContext = northwindContext;
        }
            
        public async Task<IActionResult> Index()
        {
           // var categories = await northwindContext.Categories.ToListAsync();
           var categories = await servizioCategorie.GetCategoriesIndexViewModelAsync();
           return View(categories);    
        }


        public IActionResult Create() {
            return View();
        }

        [HttpPost]  
        public  async Task<IActionResult> Create(CategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await servizioCategorie.AddCategoryAsync(model);
                //await servizioCategorie.AddCategoryEntity(new Category
                //{
                //    CategoryName = "Prova",
                //    Description = "bla bla",
                //    Products = new List<Product>
                //    {
                //        new Product { ProductName = "prodotto di prova"}
                //    }
                //});
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id) 
        {  
            var categoryDb = await servizioCategorie.GetCategorybyId(id);
            if(categoryDb == null)
                return NotFound();
            return View(categoryDb);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditViewModels model)
        {
            if (ModelState.IsValid)
            {
               await servizioCategorie.UpdateCategoryAsync(model);
            }
            return RedirectToAction("Index");
        }


    }
}
