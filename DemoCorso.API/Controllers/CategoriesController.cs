using DemoCorso.Core.Northwind.DTOs;
using DemoCorso.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DemoCorso.Core.Northwind;

namespace DemoCorso.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly INorthWindCategoryData categoryData;

        public CategoriesController(INorthWindCategoryData categoryData)
        {
            this.categoryData = categoryData;
        }


        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await categoryData.GetAsync();
                if(categories == null)
                {
                    return NotFound();  
                } else
                {
                    return Ok(categories);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }            
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            try
            {
                var category = await categoryData.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(category);
                }

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, 
                    ex.Message);
            }

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Create(CategoryCreateDTO category)
        {
           if(category == null) return BadRequest();

           var cat = await categoryData.CreateWithCategoryAsync(category);
           return CreatedAtAction(nameof(GetById), new { id = cat.Id}, cat);
        }


    }
}
