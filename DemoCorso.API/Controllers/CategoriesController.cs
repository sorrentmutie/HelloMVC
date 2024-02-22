using DemoCorso.Core.Northwind.DTOs;
using DemoCorso.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoCorso.Data.ExtensionsMethods;
using AutoMapper;

namespace DemoCorso.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly NorthwindContext northwindContext;
        private readonly IMapper mapper;

        public CategoriesController(NorthwindContext northwindContext,
            IMapper mapper)
        {
            this.northwindContext = northwindContext;
            this.mapper = mapper;
           
            // I want to use automapper to map List<Category> to List<CategoryDTO>
            // I want to use automapper to map List<CategoryAttribute> to List<CategoryAttributeDTO>



        }


        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = (await northwindContext.Categories
                .Include(c => c.Products)
                .ThenInclude(p => p.Supplier)
                .ToListAsync());
            //.ToDTO();
            var categoriesDTO = mapper.Map<List<CategoryDTO>>(categories);
            try
            {
                return Ok(categoriesDTO);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

            
        }
    }
}
