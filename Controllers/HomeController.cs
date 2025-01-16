//using Microsoft.AspNetCore.Components;
using CalculatorASPWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorASPWebApp.Controllers
{

    public class HomeController : Controller
    {
        [Route("Home")]
        public string Index()
        {
            return "Welcome To Home Controller";
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

        [Route("/Employee/John")]
        public JsonResult Employee()
        {
            Employee emp = new Employee()
            {
                Id = 101,
                Age = 27,
                Name = "John Miller",
                Salary = 2100000
            };


            return JsonResult(emp, "application/json");
        }

    }
}



