using Microsoft.AspNetCore.Mvc;

namespace CalculatorASPWebApp.Controllers
{
    public class BookControllers : Controller
    {
        //Books?IsLogged=true?BookId=200
        [Route("/Books")]
        public IActionResult Book()
        {
            if (!Request.Query.ContainsKey("BookId"))
            {
                //Response.StatusCode = 500;
                return BadRequest("Book Id is Not provided!");
            }
            int bookId = Convert.ToInt32(Request.Query["BookId"]);
            if (bookId < 1 || bookId > 1000)
            {
                return NotFound("Book ID is not in range of 1 too 1000!");
            }

            if (!Convert.ToBoolean(Request.Query["IsLogged"]))
            {
                return Unauthorized("You are not logged in!");
            }

            return File("/Samples/Sample.pdf", "application/pdf");
        }
    }
}
