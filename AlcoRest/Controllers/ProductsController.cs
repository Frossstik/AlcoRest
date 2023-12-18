using Microsoft.AspNetCore.Mvc;
using AlcoRest.Data.Models;
using AutoMapper;
using AlcoRest.Services.Dtos;
using AlcoRest.Interfaces;
using AlcoRest.Data;

namespace AlcoRest.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IBaseRepository<Product> products;
        private readonly IMapper mapper;

        public ProductsController(IBaseRepository<Product> products, IMapper mapper)
        {
            this.products = products;
            this.mapper = mapper;
        }


        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(products.GetAll());
        }

        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            return new JsonResult(products.GetById(id));
        }

        [HttpPost]
        public JsonResult Post(ProductDto product)
        {
            var _product = mapper.Map<Product>(product);
            return new JsonResult(products.Create(_product));
        }


        
        [HttpPut("{id}")]
        public JsonResult Put(Product product, int id)
        {
            bool success = true;
            //var product = mapper.Map<Product>(productDto);
            var _product = products.GetById(id);
            
            try
            {
                if (_product != null)
                {
                    _product = products.Update(product);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? new JsonResult($"Update successful {product.id}") : new JsonResult("Update was not successful");
        }

        

        /*[HttpPut("{id}")]
        public ActionResult<Product> Put(Product product, int id)
        {
            try
            {
                if (id != product.id)
                    return BadRequest("Id");
                var _product = products.GetById(id);

                if (_product == null)
                    return NotFound("Not found");

                return products.Update(product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "");
            }
        }*/

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            bool success = true;
            var _product = products.GetById(id);

            try
            {
                if (_product != null)
                {
                    products.Delete(_product.id);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult("Delete successful") : new JsonResult("Delete was not successful");
        }
    }
}
