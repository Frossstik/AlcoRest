using AlcoRest.Data.Models;
using AlcoRest.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlcoRest.Controllers
{
    [ApiController]
    [Route("/")]
    [Produces("application/json")]
    public class HomeController : ControllerBase
    {
        private IBaseRepository<Product> products;
        private IBaseRepository<Category> categories;

        public HomeController(IBaseRepository<Product> products, IBaseRepository<Category> categories)
        {
            this.products = products;
            this.categories = categories;
        }

        [HttpGet]
        public List<JsonResult> HomePage()
        {
            List<JsonResult> jsonResults = new List<JsonResult>();
            JsonResult showProducts = new JsonResult(products.GetAll());
            JsonResult showControllers = new JsonResult(categories.GetAll());
            jsonResults.Add(showProducts);
            jsonResults.Add(showControllers);
            return jsonResults;
        }
    }
}
