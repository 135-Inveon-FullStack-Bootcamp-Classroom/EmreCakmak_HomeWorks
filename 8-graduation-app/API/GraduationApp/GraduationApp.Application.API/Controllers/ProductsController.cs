using GraduationApp.Business.Engines.Interfaces;
using GraduationApp.Business.Engines.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationApp.Application.API.Controllers
{
    
    public class ProductsController : BaseController
    {
        private readonly IProductEngine _productEngine;

        public ProductsController(IProductEngine productEngine)
        {
            _productEngine = productEngine;
        }

        [HttpGet]
        public IActionResult GetBestSellersProducts()
        {
            var products = _productEngine.GetBestSellersProductList();

            return Ok(products);
        }

       

        [HttpGet("{productId:int}",Name = "GetProduct")]
        public IActionResult GetProduct(int productId)
        {
            var product = _productEngine.GetProduct(productId);

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductCreateModel productDto)
        {
            if (productDto == null)
            {
                return BadRequest(ModelState);
            }

            var product=_productEngine.GetAllProductList().Where(p => p.Name == productDto.Name).FirstOrDefault();

            if (product!=null)
            {
                ModelState.AddModelError("", "bu isimde Product zaten mevcut!");
                return StatusCode(404, ModelState);
            }

            _productEngine.CreateProduct(productDto);

            return Ok();
        }

        [HttpPut("{productId:int}", Name = "UpdateProduct")]
        public IActionResult UpdateProduct(int productId,[FromBody] ProductUpdateModel productDto)
        {
            if (productDto == null || productId != productDto.Id)
            {
                return BadRequest(ModelState);
            }

            _productEngine.UpdateProduct(productDto);

            return NoContent();
        }

        [HttpDelete("{productId:int}", Name = "DeleteProduct")]
        public IActionResult DeleteProduct(int productId)
        {
            if(!_productEngine.ProductExists(productId))
            {
                return NotFound();
            }

            var product = _productEngine.GetProduct(productId);

            _productEngine.DeleteProduct(product);

            return NoContent();
        }
    }
}
