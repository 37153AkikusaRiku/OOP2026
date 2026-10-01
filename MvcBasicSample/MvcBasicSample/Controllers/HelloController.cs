using MvcBasicSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace MvcBasicSample.Controllers {

    public class HelloController : Controller {

        public IActionResult Index() {
            var product = new List<Product> {
            new Product{
                Name = "ノート",
                Price = 250
            },
            new Product {
                Name = "ペン",
                Price = 150
            }};
            return View(product);
        }
    }
}