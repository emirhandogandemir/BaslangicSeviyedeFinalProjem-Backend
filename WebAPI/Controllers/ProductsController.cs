 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 using Business.Abstract;
 using Business.Concrete;
 using DataAccess.Concrete.EntityFramework;
 using Entities.Concrete;
using System.Threading;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]//api/products controllerin adını yazıyoruz sonrasında apiden sonra
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely Coupled --> esnek bağımlılık
        //naming convention
        //IoC Container denilen yapı
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //Dependency Chain --
            Thread.Sleep(1000);
         var result = _productService.GetAll();
         if (result.Success)
         {
             return Ok(result);
         }

         return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
