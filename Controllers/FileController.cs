using Microsoft.AspNetCore.Mvc;

namespace CalculatorASPWebApp.Controllers
{
    public class FileController : Controller
    {
        [Route("File/Download-file")]
        public IActionResult Index()
        {
            return File("/Samples/Sample.pdf","application/pdf");
        }

        [Route("File/Download-file-2")]
        public IActionResult FileDownload()
        {
            return File("D:\\Storage\\Sample.pdf", "application/pdf");
        }

        [Route("File/Download-file-3")]
        public IActionResult FileDownload2()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"D:\Storage\Sample.pdf");
            return File(bytes, "application/pdf");
        }
    }
}
