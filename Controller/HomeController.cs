//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorASPWebApp.Controller
{
    
    public class HomeController
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

        

    }
}



