using CalculatorASPWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorASPWebApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home")]
        [Route("/")]
        public IActionResult Index()
        {
            return new ContentResult()
            {
                Content = "Welcome To Home Controller",
                ContentType = "text/html"
            };

        }

        [Route("/Employee/John")]
        public IActionResult Employee()
        {
            Employee emp = new Employee()
            {
                Id = 101,
                Age = 27,
                Name = "John Miller",
                Salary = 210000
            };
            return Json(emp);//, "application/json");
        }
        [Route("About")]
        public string About()
        {
            return "You are in About Page.";
        }

        [Route("Contact-us")]
        public string Contact()
        {
            return "You are in Contact Us Page.";
        }

        [Route("/products/{id:int:min(1000):max(9999)}")]
        public string Products()
        {
            return "You are in Products Page.";
        }

    }
}



