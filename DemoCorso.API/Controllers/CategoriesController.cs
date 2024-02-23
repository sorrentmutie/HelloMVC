using DemoCorso.Core.Northwind.DTOs;
using DemoCorso.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoCorso.Data.ExtensionsMethods;
using AutoMapper;
using DemoCorso.API.Services;
using DemoCorso.Core.Northwind;

namespace DemoCorso.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly INorthwindCategoryData categoryData;

        public CategoriesController(INorthwindCategoryData categoryData)
        {
            this.categoryData = categoryData;
        }


        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await categoryData.GetAsync();
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("ID must be greater than 0");

                var category = await categoryData.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CategoryCreateDTO category)
        {
            try
            {
                if (category == null)
                    return BadRequest("category is NULL");

                var cat = await categoryData.CreateWithCategoryAsync(category);
                return CreatedAtAction(nameof(GetById), new { id = cat.Id }, cat);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchCategory(int id, CategoryUpdateDTO category)
        {
            try
            {
                if (category == null)
                    return BadRequest("category is NULL");

                if (id != category.Id)
                    return BadRequest("IDs mismatch");

                await categoryData.PatchAsync(category);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutCategory(int id, CategoryUpdateDTO category)
        {
            try
            {
                if (category == null)
                    return BadRequest("category is NULL");

                if (id != category.Id)
                    return BadRequest("IDs mismatch");

                await categoryData.UpdateAsync(category);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("ID must be greater than 0");

                await categoryData.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
