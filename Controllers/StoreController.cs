using Microsoft.AspNetCore.Mvc;

namespace CalculatorASPWebApp.Controllers
{
    public class StoreController : Controller
    {
        [Route("/category/books/{isLogged}/{bookId}")]
        public IActionResult Books()
        {
            if (!Request.RouteValues.ContainsKey("BookId"))
            {
                //Response.StatusCode = 500;
                return BadRequest("Book Id is Not provided!");
            }
            int bookId = Convert.ToInt32(Request.RouteValues["BookId"]);
            if (bookId < 1 || bookId > 1000)
            {
                return NotFound("Book ID is not in range of 1 too 1000!");
            }

            if (!Convert.ToBoolean(Request.RouteValues["IsLogged"]))
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized);
            }
            return Content("New Book Page", "text/plain");
        }
    }
}
//http://localhost:5162/Books?IsLogged=true&BookId=200
//http://localhost:5162/Books?IsLogged=true&BookId=786