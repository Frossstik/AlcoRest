using AlcoRest.Data.Models;
using AlcoRest.Interfaces;
using AlcoRest.Services.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlcoRest.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Produces("application/json")]
    public class CategoriesController : ControllerBase
    {
        private IBaseRepository<Category> categories;

        private IMapper mapper;

        public CategoriesController(IBaseRepository<Category> categories, IMapper mapper)
        {
            this.categories = categories;
            this.mapper = mapper;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(categories.GetAll());
        }

        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            return new JsonResult(categories.GetById(id));
        }

        [HttpPost]
        public JsonResult Post(CategoryDto category)
        {
            var _category = mapper.Map<Category>(category);
            return new JsonResult(categories.Create(_category));
        }

        [HttpPut]
        public JsonResult Put(Category category)
        {
            bool success = true;
            var _product = categories.GetById(category.id);
            try
            {
                if (_product != null)
                {
                    _product = categories.Update(category);
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
            return success ? new JsonResult($"Update successful {_product.id}") : new JsonResult("Update was not successful");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            bool success = true;
            var _product = categories.GetById(id);

            try
            {
                if (_product != null)
                {
                    categories.Delete(_product.id);
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
