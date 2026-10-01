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
                Name = "ポテト",
                Price = 350
            }};
            return View(product);
        }
    }
}