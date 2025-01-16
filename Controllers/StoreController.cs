using Microsoft.AspNetCore.Mvc;

namespace CalculatorASPWebApp.Controllers
{
    public class StoreController : Controller
    {
        [Route("/category/books")]
        public IActionResult Books()
        {
            return Content("New Book Page", "text/plain");
        }
    }
}
