using GraduationApp.Business.Engines.Interfaces;
using GraduationApp.Business.Engines.Models.Category;
using GraduationApp.Business.Engines.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationApp.Application.API.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICatalogEngine _catalogEngine;

        public CategoriesController(ICatalogEngine catalogEngine)
        {
            _catalogEngine = catalogEngine;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _catalogEngine.GetAllCategoryList();

            return Ok(categories);
        }

        [HttpGet("{id}/Products")]
        public List<ProductOverViewModel> GetCategoryProducts(int id)
        {
            var data = _catalogEngine.GetProductListByCategoryIdForCatalog(id);
            return data;
        }

        [HttpGet("{categoryId:int}", Name = "GetCategory")]     
        public IActionResult GetCategory(int categoryId)
        {
            var category = _catalogEngine.GetCategory(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryCreateModel categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest(ModelState);
            }

            var category = _catalogEngine.GetAllCategoryList().Where(p => p.Name == categoryDto.Name).FirstOrDefault();

            if (category != null)
            {
                ModelState.AddModelError("", "bu isimde Category zaten mevcut!");
                return StatusCode(404, ModelState);
            }

            _catalogEngine.CreateCategory(categoryDto);

            return Ok();
        }

        [HttpPut("{categoryId:int}", Name = "UpdateCategory")]
        public IActionResult UpdateCategory(int categoryId, [FromBody] CategoryOverViewModel categoryDto)
        {
            if (categoryDto == null || categoryId != categoryDto.Id)
            {
                return BadRequest(ModelState);
            }

            _catalogEngine.UpdateCategory(categoryDto);

            return NoContent();
        }

        [HttpDelete("{categoryId:int}", Name = "DeleteCategory")]
        public IActionResult DeleteCategory(int categoryId)
        {
            if (!_catalogEngine.CategoryExists(categoryId))
            {
                return NotFound();
            }


            var category = _catalogEngine.GetCategory(categoryId);

            _catalogEngine.DeleteCategory(category);

            return NoContent();
        }
    }
}
